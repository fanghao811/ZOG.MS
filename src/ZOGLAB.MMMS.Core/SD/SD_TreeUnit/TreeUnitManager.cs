using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.UI;
using Abp.Zero;

namespace ZOGLAB.MMMS.SD
{
    //TODO:完成TreeUnitManager的具体实现
    //参考:https://github.com/fanghao811/aspnetboilerplate/blob/dev/src/Abp.Zero.Common/Organizations/TreeUnitManager.cs:

    /// <summary>
    /// Performs domain logic for Organization Units.
    /// </summary>
    public class TreeUnitManager<Tunit>  : DomainService where Tunit:class,ITreeUnit, IEntity<long>
    {
        protected IRepository<Tunit, long> _treeUnitRepository { get; private set; }

        public TreeUnitManager(IRepository<Tunit, long> treeUnitRepository)
        {
            _treeUnitRepository = treeUnitRepository;

            LocalizationSourceName = AbpZeroConsts.LocalizationSourceName;
        }

        [UnitOfWork]
        public virtual async Task CreateAsync(Tunit treeUnit)
        {
            treeUnit.Code = await GetNextChildCodeAsync(treeUnit.ParentId, treeUnit.CodeUnitLength);
            await ValidateTreeUnitAsync(treeUnit);
            await _treeUnitRepository.InsertAsync(treeUnit);
        }

        public virtual async Task UpdateAsync(Tunit treeUnit)
        {
            await ValidateTreeUnitAsync(treeUnit);
            await _treeUnitRepository.UpdateAsync(treeUnit);
        }

        public virtual async Task<string> GetNextChildCodeAsync(long? parentId, int codeUnitLength)
        {
            var lastChild = await GetLastChildOrNullAsync(parentId);
            if (lastChild == null)
            {
                var parentCode = parentId != null ? await GetCodeAsync(parentId.Value) : null;
                return AppendCode(parentCode, CreateCode(codeUnitLength, 1));
            }

            return CalculateNextCode(lastChild.Code, lastChild.CodeUnitLength);
        }

        public virtual async Task<Tunit> GetLastChildOrNullAsync(long? parentId)
        {
            var children = await _treeUnitRepository.GetAllListAsync(ou => ou.ParentId == parentId);
            return children.OrderBy(c => c.Code).LastOrDefault();
        }

        public virtual async Task<string> GetCodeAsync(long id)
        {
            return (await _treeUnitRepository.GetAsync(id)).Code;
        }

        [UnitOfWork]
        public virtual async Task DeleteAsync(long id)
        {
            var children = await FindChildrenAsync(id, true);

            foreach (var child in children)
            {
                await _treeUnitRepository.DeleteAsync(child);
            }

            await _treeUnitRepository.DeleteAsync(id);
        }

        [UnitOfWork]
        public virtual async Task MoveAsync(long id, long? parentId)
        {
            var treeUnit = await _treeUnitRepository.GetAsync(id);
            if (treeUnit.ParentId == parentId)
            {
                return;
            }

            //Should find children before Code change
            var children = await FindChildrenAsync(id, true);

            //Store old code of OU
            var oldCode = treeUnit.Code;

            //Move OU
            treeUnit.Code = await GetNextChildCodeAsync(parentId, treeUnit.CodeUnitLength);
            treeUnit.ParentId = parentId;

            await ValidateTreeUnitAsync(treeUnit);

            //Update Children Codes
            foreach (var child in children)
            {
                child.Code = AppendCode(treeUnit.Code,GetRelativeCode(child.Code, oldCode));
            }
        }

        public async Task<List<Tunit>> FindChildrenAsync(long? parentId, bool recursive = false)
        {
            if (!recursive)
            {
                return await _treeUnitRepository.GetAllListAsync(ou => ou.ParentId == parentId);
            }

            if (!parentId.HasValue)
            {
                return await _treeUnitRepository.GetAllListAsync();
            }

            var code = await GetCodeAsync(parentId.Value);

            return await _treeUnitRepository.GetAllListAsync(
                ou => ou.Code.StartsWith(code) && ou.Id != parentId.Value
            );
        }

        protected virtual async Task ValidateTreeUnitAsync(Tunit treeUnit)
        {
            var siblings = (await FindChildrenAsync(treeUnit.ParentId))
                .Where(ou => ou.Id != treeUnit.Id)
                .ToList();

            if (siblings.Any(ou => ou.DisplayName == treeUnit.DisplayName))
            {
                throw new UserFriendlyException(L("TreeUnitDuplicateDisplayNameWarning", treeUnit.DisplayName));
            }
        }


        /// <summary>
        /// Creates code for given numbers.
        /// Example: if numbers are 4,2 then returns "00004.00002";
        /// </summary>
        /// <param name="numbers">Numbers</param>
        public static string CreateCode(int codeUnitLength,params int[] numbers)
        {
            if (numbers.IsNullOrEmpty())
            {
                return null;
            }

            return numbers.Select(number => number.ToString(new string('0', codeUnitLength))).JoinAsString(".");
        }

        /// <summary>
        /// Appends a child code to a parent code. 
        /// Example: if parentCode = "00001", childCode = "00042" then returns "00001.00042".
        /// </summary>
        /// <param name="parentCode">Parent code. Can be null or empty if parent is a root.</param>
        /// <param name="childCode">Child code.</param>
        public static string AppendCode(string parentCode, string childCode)
        {
            if (childCode.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(childCode), "childCode can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return childCode;
            }

            return parentCode + "." + childCode;
        }

        /// <summary>
        /// Gets relative code to the parent.
        /// Example: if code = "00019.00055.00001" and parentCode = "00019" then returns "00055.00001".
        /// </summary>
        /// <param name="code">The code.</param>
        /// <param name="parentCode">The parent code.</param>
        public static string GetRelativeCode(string code, string parentCode)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            if (parentCode.IsNullOrEmpty())
            {
                return code;
            }

            if (code.Length == parentCode.Length)
            {
                return null;
            }

            return code.Substring(parentCode.Length + 1);
        }

        /// <summary>
        /// Calculates next code for given code.
        /// Example: if code = "00019.00055.00001" returns "00019.00055.00002".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string CalculateNextCode(string code,int codeUnitLength)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var parentCode = GetParentCode(code);

            var lastUnitCode = GetLastUnitCode(code);

            if (Convert.ToInt32(lastUnitCode)>=Math.Pow(10, codeUnitLength) -1)
            {
                throw new ArgumentNullException(nameof(code), "code is out of Max");
            }

            return AppendCode(parentCode, CreateCode(codeUnitLength,Convert.ToInt32(lastUnitCode) + 1));
        }

        /// <summary>
        /// Gets the last unit code.
        /// Example: if code = "00019.00055.00001" returns "00001".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetLastUnitCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            return splittedCode[splittedCode.Length - 1];
        }

        /// <summary>
        /// Gets parent code.
        /// Example: if code = "00019.00055.00001" returns "00019.00055".
        /// </summary>
        /// <param name="code">The code.</param>
        public static string GetParentCode(string code)
        {
            if (code.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(code), "code can not be null or empty.");
            }

            var splittedCode = code.Split('.');
            if (splittedCode.Length == 1)
            {
                return null;
            }

            return splittedCode.Take(splittedCode.Length - 1).JoinAsString(".");
        }
    }
}
