using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pollia.Utils
{
    public enum EPlaceServeStatus
    {
        [Display(Name = "Đóng cửa")]
        Closed = 0,
        [Display(Name = "Mở cửa")]
        Open = 1,
        [Display(Name = "Sữa chữa")]
        Fixing = 2,
        [Display(Name = "Quá tải")]
        Overload = 3,
        [Display(Name = "Chưa xác nhận")]
        Unconfirmed = 4
    }

    public enum EEventServeStatus
    {
        [Display(Name = "Đóng cửa")]
        Closed = 0,
        [Display(Name = "Mở cửa")]
        Open = 1,
        [Display(Name = "Sữa chữa")]
        Fixing = 2,
        [Display(Name = "Quá tải")]
        Overload = 3,
        [Display(Name = "Chưa xác nhận")]
        Unconfirmed = 4
    }
}