using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOGLAB.MMMS.SD
{
    /// <summary>
    /// Represents an organization unit (OU).
    /// </summary>
    [Table("TreeUnit")]
    public class TreeUnit : FullAuditedEntity<long>, ITreeUnit
    {
        /// <summary>
        /// Maximum length of the <see cref="DisplayName"/> property.
        /// </summary>
        public const int MaxDisplayNameLength = 128;

        /// <summary>
        /// Maximum depth of an UO hierarchy. 16
        /// </summary>
        public const int Depth = 5;

        /// <summary>
        /// Length of a code unit between dots. 5
        /// </summary>
        public const int UnitLength = 5;

        /// <summary>
        /// Maximum length of the <see cref="Code"/> property.
        /// </summary>
        public const int MaxCodeLength = Depth * (UnitLength + 1) - 1;

        public virtual int CodeUnitLength
        {
            get { return UnitLength; }
        }

        /// <summary>
        /// Parent <see cref="TreeUnit"/>.
        /// Null, if this OU is root.
        /// </summary>
        [ForeignKey("ParentId")]
        public virtual ITreeUnit Parent { get; set; }

        /// <summary>
        /// Parent <see cref="TreeUnit"/> Id.
        /// Null, if this OU is root.
        /// </summary>
        public virtual long? ParentId { get; set; }

        /// <summary>
        /// Hierarchical Code of this organization unit.
        /// Example: "00001.00042.00005".
        /// This is a unique code for a Tenant.
        /// It's changeable if OU hierarch is changed.
        /// </summary>
        [Required]
        [StringLength(MaxCodeLength)]
        public virtual string Code { get; set; }

        /// <summary>
        /// Display name of this role.
        /// </summary>
        [Required]
        [StringLength(MaxDisplayNameLength)]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Children of this OU.
        /// </summary>
        public virtual ICollection<ITreeUnit> Children { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeUnit"/> class.
        /// </summary>
        public TreeUnit()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeUnit"/> class.
        /// </summary>
        /// <param name="tenantId">Tenant's Id or null for host.</param>
        /// <param name="displayName">Display name.</param>
        /// <param name="parentId">Parent's Id or null if OU is a root.</param>
        public TreeUnit(string displayName, long? parentId = null)
        {
            DisplayName = displayName;
            ParentId = parentId;
        }

    }
}