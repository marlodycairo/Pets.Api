using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas.Api.Infrastructure.Responses
{
    public class ResponseMessage
    {
        public const string RecordExist = "The record is already exists.";
        public const string RecordNotExist = "The record don't exists.";
        public const string RecordSuccessfullSaved = "The record was successfully saved.";
        public const string RecordUpdated = "The record was successfully updated";
        public const string RecordIsNull = "Empty spaces are not allowed, you must enter a record.";
    }
}
