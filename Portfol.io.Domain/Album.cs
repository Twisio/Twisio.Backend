﻿namespace Portfol.io.Domain
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Likes { get; set; }
        public bool IsLiked { get; set; } = false;
        public Guid UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Photo>? Photos { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
        public virtual ICollection<AlbumTag>? AlbumTags { get; set; }
    }
}
