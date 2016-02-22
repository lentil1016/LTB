using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication16
{

    /// <summary>  
    /// Using Singleton Design Pattern  
    /// </summary>  
    public class WaitFormService
    {

        /// <summary>  
        /// 单例模式  
        /// </summary>  
        public static WaitFormService Instance
        {
            get
            {
                if (WaitFormService._instance == null)
                {
                    lock (syncLock)
                    {
                        if (WaitFormService._instance == null)
                        {
                            WaitFormService._instance = new WaitFormService();
                        }
                    }
                }
                return WaitFormService._instance;
            }
        }

        /// <summary>  
        /// 为了单例模式防止new 实例化..  
        /// </summary>  
        private WaitFormService()
        {
        }


        private static WaitFormService _instance;
        private static readonly Object syncLock = new Object();
        private Thread waitThread;
        private static WaitForm waitForm;
        /// <summary>  
        /// 显示等待窗体  
        /// </summary>  
        public static void Show()
        {

            //try  
            //{              
            WaitFormService.Instance._CreateForm();
            //isclose = false;  
            //}  
            //catch (Exception ex)  
            //{   
            //}  
        }

        /// <summary>  
        /// 关闭等待窗体  
        /// </summary>  
        public static void Close()
        {

            //if (isclose == true)  
            //{  
            //    return;  
            //}  
            //try  
            //{  
            Thread.Sleep(100);
            WaitFormService.Instance._CloseForm();
            //isclose = true;  
            //}  
            //catch (Exception ex)  
            //{   
            //}  
        }

        /// <summary>  
        /// 设置等待窗体标题  
        /// </summary>  
        /// <param name="text"></param>  
        public static void SetText(string text)
        {
            //if (isclose == true)  
            //{  
            //    return;  
            //}  
            //try  
            //{  
            WaitFormService.Instance.SetWaiteText(text);
            //}  
            //catch (Exception ex)  
            //{   
            //}  
        }


        /// <summary>  
        /// 创建等待窗体  
        /// </summary>  
        public void _CreateForm()
        {
            waitForm = null;
            waitThread = new Thread(new ThreadStart(this._ShowWaitForm));
            waitThread.Start();
            Thread.Sleep(100);
        }

        private void _ShowWaitForm()
        {
            try
            {
                waitForm = new WaitForm();
                waitForm.ShowDialog();
                //Application.Run(waitForm);  
            }
            catch (ThreadAbortException e)
            {
                waitForm.Close();
                Thread.ResetAbort();
            }
        }

        /// <summary>  
        /// 关闭窗体  
        /// </summary>  
        private void _CloseForm()
        {

            //waitForm.Close();  
            //waitForm = null;  
            if (waitThread != null)
            {
                waitForm.Close(); //waitThread.Abort();
            }
        }


        /// <summary>  
        /// 设置窗体标题  
        /// </summary>  
        /// <param name="text"></param>  
        public void SetWaiteText(string text)
        {
            if (waitForm != null)
            {
                //try  
                //{  

                waitForm.Show();

                waitForm.SetText(text);
                //}  
                //catch (Exception ex)  
                //{   
                //}  
            }
        }

    }
}
