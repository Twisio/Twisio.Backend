﻿using MediatR;

namespace Portfol.io.Application.Aggregate.Photos.Commands.DeleteImage
{
    public class DeleteImageCommand : IRequest<Unit>
    {
        public int AlbumId { get; set; }
        public int PhotoId { get; set; }
        public string WebRootPath { get; set; } = null!;
    }
}