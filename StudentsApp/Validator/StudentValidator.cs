using StudentsApp.DTO;

namespace StudentsApp.Validator
{
    public class StudentValidator
    {
        private StudentValidator() { }

        public static string Validate(StudentDTO? dto) 
        {
            if ((dto!.Firstname!.Length == 0) || (dto!.Lastname!.Length == 0))
            {
                return "Firstname / Lastname can not be empty";
            }

            return "";
        }
    }
}
