﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Logger;
using Logger;

namespace TestUngDung.Common
{
    public class Common { 
    //{
    //    ///<summary>
    //    ///Ghi log lỗi và quy trình
    //    ///Input: sPage (Tên của trang cần log)
    //    ///</summary>
    //    public static void WriteLog(string sPage, string sFunction, string sMessage)
    //    {
    //        try
    //        {
    //            string LogPath = HttpContext.Current.Server.MapPath("~/LogInfo");
    //            if (!System.IO.Directory.Exists(LogPath))
    //            {
    //                System.IO.Directory.CreateDirectory(LogPath);
    //            }
    //            Logger TestLogger = new CLogger();
    //            TestLogger.Initialize(LogPath, "SHOP.log", 2);
    //            TestLogger.LogInformation(sPage, sFunction, sMessage);
    //            TestLogger.Terminate();
    //        }
    //        catch (Exception)
    //        {

    //        }
    //    }
    }
}