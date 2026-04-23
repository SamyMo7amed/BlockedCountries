namespace BlockedCountriesApi.Bases.ResponseBases
{
    public class ResponseHandler
    {


        public Response<T> Success<T>(T entity, object meta = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Meta = meta,
                Message = "Success"
                ,
                Data = entity

            };

        }
        public Response<T> Unauthorized<T>(string message = null)
        {
            return new Response<T>()
            {
                Message = message == null ? "UnAuthorized" : message,
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = false,


            };

        }

        public Response<T> Deleted<T>(string message = null)
        {
            return new Response<T>()
            {

                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = message == null ? "Deleted" : message,


            };

        }

        public Response<T> BadRequest<T>(string messag = null)
        {
            return new Response<T>()

            {
                Message = messag == null ? "BadRequest" : messag,
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false

            };

        }

        public Response<T> UnprocessableEntity<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = message == null ? "UnprocessableEntity" : message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "NotFound" : message
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                Meta = Meta
            };

        }
    }
}
