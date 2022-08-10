﻿using AutoMapper;
using Portfol.io.Application.Common.Mappings;
using Portfol.io.Domain;

namespace Portfol.io.Application.Aggregate.Albums.Queries.GetAlbumById
{
    public class AlbumViewModel : IMapWith<Album>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public IEnumerable<Photo> Photos { get; set; } = null!;
        public IEnumerable<Tag> Tags { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, AlbumViewModel>()
                .ForMember(albumLookup => albumLookup.Id, opt => opt.MapFrom(album => album.Id))
                .ForMember(albumLookup => albumLookup.Name, opt => opt.MapFrom(album => album.Name))
                .ForMember(albumLookup => albumLookup.Description, opt => opt.MapFrom(album => album.Description))
                .ForMember(albumLookup => albumLookup.CreationDate, opt => opt.MapFrom(album => album.CreationDate))
                .ForMember(albumLookup => albumLookup.Photos, opt => opt.MapFrom(album => album.Photos))
                .ForMember(albumLookup => albumLookup.Tags, opt => opt.MapFrom(album => album.Tags));
        }
    }
}