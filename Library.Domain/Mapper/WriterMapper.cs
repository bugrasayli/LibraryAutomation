using Library.Domain.DTO.Writer;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Mapper
{
    public class WriterMapper : IWriterMapper
    {
        public Writer Map(AddWriterRequest writer)
        {
            if (writer == null)
                return null;
            return new Writer
            {
                Name = writer.Name
            };
        }

        public Writer Map(EditWriterRequest writer)
        {
            if (writer == null)
                return null;
            return new Writer
            {
                ID = writer.ID,
                Name = writer.Name
            };
        }

        public WriterResponse Map(Writer writer)
        {
            if (writer == null)
                return null;
            return new WriterResponse
            {
                ID = writer.ID,
                Name = writer.Name
            };
        }
    }
}
