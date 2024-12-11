namespace Curdoperation.Utilities
{
   
        public class ServiceResponse<T>
        {
            public bool Success { get; set; }
            public T? Data { get; set; }
            public string? ErrorMessage { get; set; }

            public string? ResultMessage { get; set; }

            

        }
    }

