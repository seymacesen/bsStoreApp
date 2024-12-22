
namespace Entities.Exceptions
{
    public abstract class NotFoundException:Exception
    {
        protected NotFoundException(string message): base(message) 
        {
        
        }//custom hata typeini yobtecek şekilde adım atmış olduk

    }
}
