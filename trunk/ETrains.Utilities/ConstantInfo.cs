namespace ETrains.Utilities
{
    public class ConstantInfo
    {
        /// <summary>
        /// Cấp Chi Cục
        /// </summary>
        public static string Branch = "Cấp Chi Cục";
        /// <summary>
        /// Cấp Cục
        /// </summary>
        public static string Boss = "Cấp Cục";

        #region Table User
        public const string TBL_USER_USERID = "UserID";
        public const string TBL_USER_NAME = "Name";
        public const string TBL_USER_SEX = "Sex";
        public const string TBL_USER_BIRTHDAY = "Birthday";
        public const string TBL_USER_ADDRESS = "Address";
        public const string TBL_USER_EMAIL = "Email";
        public const string TBL_USER_PHONE_NUMBER = "PhoneNumber";
        public const string TBL_USER_USERNAME = "UserName";
        public const string TBL_USER_PASSWORD = "Password";
        public const string TBL_USER_PERMISSION = "Permission";        
        public const string TBL_USER_IS_ACTIVE = "IsActive";
        #endregion

        #region Table Permission 
        public const string TBL_PERMISSION_PERMISSION_ID = "PermissionID";
        public const string TBL_PERMISSION_PERMISSION = "Permission";
        #endregion

        #region Message

        public const string MESSAGE_INSERT_SUCESSFULLY = "Tạo mới xong.";
        public const string MESSAGE_INSERT_NOT_SUCESSFULLY = "Tạo mới lỗi (Trạng thái dữ liệu đã thay đổi bởi hành động khác, hoặc mất kết nối với server)";
        public const string MESSAGE_UPDATE_SUCESSFULLY = "Cập nhật xong ";
        public const string MESSAGE_UPDATE_FAIL = "Cập nhật lỗi (Trạng thái dữ liệu đã thay đổi bởi hành động khác, hoặc mất kết nối với server)";
        public const string MESSAGE_SAVE_UNSUCESSFULLY = "Lưu không không thành công (Trạng thái dữ liệu đã thay đổi bởi hành động khác, hoặc mất kết nối với server)";

        public const string MESSAGE_LOGIN_FAIL = "Tên truy cập hoặc mật khẩu không đúng.";
        public const string MESSAGE_WELCOME = "Xin chào {0}";
        public const string MESSAGE_USERNAME_EXISTING = "Tên truy cập đã tồn tại.";        
        public const string MESSAGE_BLANK_USERNAME = "Tên truy cập không được trống.";
        public const string MESSAGE_BLANK_PASSWORD = "Mật khẩu không được trống.";
        public const string MESSAGE_COMPARE_PASSWORD = "Mật khẩu và nhập lại nhập khẩu phải giống nhau.";
        public const string MESSAGE_BLANK_EMAIL = "Bạn cần nhập Email.";
        public const string MESSAGE_WRONG_EMAIL = "Địa chỉ Email không dúng.";
        public const string MESSAGE_BLANK_DRIVER = "Tên lái xe không được trống.";
        public const string MESSAGE_INSERT_FAIL = "Tạo mới lỗi";
        public const string MESSAGE_ADD_MORE = "Bạn có muốn thêm tiếp?";
        public const string MESSAGE_ADD_DONE = "Thêm xong.";
        public const string MESSAGE_BLANK_DECLARATION_NUMBER = "Số tờ khai không được trống.";
        public const string MESSAGE_TITLE = " :: ";
        public const string MESSAGE_INCORRECT_PASS = "Mật khẩu cũ chưa đúng!";
        public const string MESSAGE_NO_VEHICLE = "Bạn cần thêm phương tiện.";
        // Group
        public const string MESSAGE_BLANK_NAME = "Tên nhóm không được trống.";
        public const string MESSAGE_GROUP_NAME_EXISTING = "Tên nhóm đã tồn tại.";
        public const string MESSAGE_GROUP_NOT_EXIST = "Nhóm không còn tồn tại, xin kiểm tra lại";
        // User in Group
        public const string MESSAGE_ADD_USER_IN_GROUP_SUCESSFULLY = "Cập nhật thành công.";
        public const string MESSAGE_ADD_USER_IN_GROUP_FAIL = "Cập nhật bị lỗi, xin kiểm tra lại kêt nối mạng";
        #endregion

        //list permission key
        public const int PERMISSON_QUAN_LY_NGUOI_DUNG = 1;
        public const int PERMISSON_QUAN_LY_TAU_HANG_XNC = 2;
        public const int PERMISSON_QUAN_LY_TAU_KHACH_XNC = 3;
        public const int PERMISSON_QUAN_LY_TO_KHAI = 4;
        public const int PERMISSON_QUAN_LY_BBBG_VA_HOI_BAO = 5;
        public const int PERMISSON_QUAN_LY_THONG_TIN_DOANH_NGHIEP = 6;
        public const int PERMISSON_TRA_CUU_THONG_TIN_DOANH_NGHIEP = 61;
        public const int PERMISSON_TAO_SO_THEO_DOI_TAU_HANG_XNC = 71;
        public const int PERMISSON_TAO_SO_THEO_DOI_TAU_KHACH_XNC = 72;
        public const int PERMISSON_TAO_SO_THEO_DOI_BBBG = 73;
        public const int PERMISSON_TAO_SO_THEO_DOI_BANG_KE_HOI_BAO_BBBG = 74;
        
        #region System

        public const string HashString = "dfkjdk234fda23fdfssf";
        public const string RgKeyApp = "SOFTWARE\\TechLink";
        public const string RgKeyAppDataPath = "AppData";
        public const string RgKeyAppUserProfilePath = "Profile";
        public const string RgKeyAppUserTimeStampPath = "TimeStamp";
        public const string RgKeySizePath = "SizeOfUnit";
        public const string RgKeyUnitCode = "UnitCode";
        public const string CurrentVersion = "1.0.0";

        #endregion
    }
}
