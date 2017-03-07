using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Json;

namespace BIMTClassLibrary.quotation
{
    /// <summary>
    /// 页码字段
    /// </summary>
    class PageRange : BaseField, IField
    {
        public string GetValue()
        {
            try
            {
                string pageRange = quotation.publishInfo.pageRange;
                if (quotation.publishInfo.pageRange == null || pageRange.Trim() == string.Empty)
                {//页码缺失
                    result = "[Epub ahead of print]";
                }
                else
                {//页码完整
                    string[] _arrayPages = pageRange.Split('-');
                    if (_arrayPages.Length == 2)
                    {
                        if (_arrayPages[0].Length > _arrayPages[1].Length)
                        {//处理1025-56这种数据情况
                            int length = _arrayPages[0].Length - _arrayPages[1].Length;
                            _arrayPages[1] = _arrayPages[0].Substring(0, length) + _arrayPages[1];
                        }
                        if (_arrayPages[0].Trim() == _arrayPages[1].Trim())
                        {//244-244页码相同
                            result = _arrayPages[0].Trim();
                        }
                        else
                        {//244-256页码不同
                            if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_NONE").ToUpper())
                            {//仅显示首页
                                result = _arrayPages[0].Trim();
                            }
                            else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_PRE_ONLY").ToUpper())
                            {
                                result = _arrayPages[0];
                            }
                            else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_LAST_ONE_WORD").ToUpper())
                            {   //保留一位
                                for (int i = 0; i < _arrayPages[0].Length; i++)
                                {
                                    if (_arrayPages[0].Substring(i, 1) != _arrayPages[1].Substring(i, 1))
                                    {
                                        result = _arrayPages[0] + "-" + _arrayPages[1].Substring(i);
                                        break;
                                    }
                                }
                            }
                            else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_LAST_TWO_WORD").ToUpper())
                            {//保留两位
                                for (int i = 0; i < _arrayPages[0].Length - 1; i++)
                                {
                                    if (_arrayPages[0].Substring(i, 1) != _arrayPages[1].Substring(i, 1) || i == _arrayPages[0].Length - 2)
                                    {
                                        result = _arrayPages[0] + "-" + _arrayPages[1].Substring(i);
                                        break;
                                    }
                                }
                            }
                            else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_FULL").ToUpper())
                            {
                                result = _arrayPages[0] + "-" + _arrayPages[1];
                            }
                            else if ("TRUE" == JsonHelper.GetValue("PAGE_TYPE_FOR").ToUpper() && pageRange == "期刊")
                            {
                                result = _arrayPages[0];
                            }
                        }
                    }
                    else
                    {
                        result = pageRange;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PageRange(Quotation quotation)
        {
            // TODO: Complete member initialization
            this.quotation = quotation;
        }
    }
}
