﻿using JP.API;
using JP.Utils.Data;
using JP.Utils.Data.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Web.Http;

namespace MyerSplashShared.API
{
    public static class CloudService
    {
        /// <summary>
        /// 获得默认的参数，
        /// 带上 a 是为了让每次服务器返回来都是最新的，也就是没有缓存的
        /// </summary>
        /// <returns></returns>
        private static List<KeyValuePair<string, string>> GetDefaultParam()
        {
            var param = new List<KeyValuePair<string, string>>();
            param.Add(new KeyValuePair<string, string>("a", new Random().Next().ToString()));
            param.Add(new KeyValuePair<string, string>("client_id", UrlHelper.AppKey));
            return param;
        }

        public static async Task<CommonRespMsg> GetImages(int page,int pageCount,CancellationToken token)
        {
            var param = GetDefaultParam();
            param.Add(new KeyValuePair<string, string>("page", page.ToString()));
            param.Add(new KeyValuePair<string, string>("per_page", pageCount.ToString()));

            var result = await APIHelper.SendGetRequestAsync(UrlHelper.MakeFullUrlForGetReq(UrlHelper.GetImages, param), token);
            return result;
        }
    }
}