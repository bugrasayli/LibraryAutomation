using Library.Domain.DTO.Writer;
using Library.Domain.Entities;
using Library.Domain.IMapper;
using Library.Domain.IValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Mapper
{
    public class WriterMapper : IWriterMapper
    {
        private readonly IWriterValidation _writerValidation;

        public WriterMapper(IWriterValidation writerValidation)
        {
            _writerValidation = writerValidation;
        }

        public Writer Map(AddWriterRequest writer)
        {
            var isValid = _writerValidation.AddWriterValidation(writer);
            if (isValid != null)
                throw new ArgumentException(isValid);

            if (writer == null)
                return null;
            return new Writer
            {
                Name = writer.Name
            };
        }

        public Writer Map(EditWriterRequest writer)
        {

            var isValid = _writerValidation.EditWriterValidation(writer);
            if (isValid != null)
                throw new ArgumentException(isValid);
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
