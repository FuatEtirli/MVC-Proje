using femotor.Models;

namespace femotor.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Motor> MotorList { get; set; }
        public IEnumerable<BodyType> BodyTypeList { get; set; }
       
      
        public string MotorName { get; set; }   
        public string BodyTypeName { get; set; }
        public string BodyType { get; set; }
        public string BodyTypeID { get; set; }
        
        public string GearTypeName { get; set; }
        
        public int ItemTotalNumber { get; set; }
        public int CurrentPageNumber { get; set; }
        public int LastPageNumber { get; set; }
        public int RecordPerPage { get; set; }

    }
}
