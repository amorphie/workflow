
namespace amorphie.workflow.service.Zeebe
{
    public class ZeebeBussinesException : Exception
    {
        public ZeebeBussinesException(string errorMessage) : this("GeneralBusiness", errorMessage)
        {
        }

        public ZeebeBussinesException(string errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
