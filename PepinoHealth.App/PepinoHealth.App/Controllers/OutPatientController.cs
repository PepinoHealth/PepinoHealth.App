using PepinoHealth.App.Filters;
using PepinoHealth.Auth.User;
using PepinoHealth.CL.Common;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using PepinoHealth.CL.User;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System;
using PepinoHealth.BL;
using PepinoHealth.CL.OPModal;
using System.Web;

namespace PepinoHealth.App.Controllers
{
    public partial class OutPatientController : Controller
    {
        #region View Action Methods



        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.OPRegistration)]
        public virtual ActionResult OPRegistration()
        {
            return View();
        }

        [SessionExpire]
        [NoCache]
        [URAC(PepinoHealth.CL.Common.Roles.Admin)]
        [HttpGet]
        [Route(Helper.OPRevisitRegistration)]
        public virtual ActionResult OPRevisitRegistration()
        {
            return View();
        }

        #endregion

        #region Common Action Methods
        dynamic returnNull = null;
        private OutPatientRepositary OutPatientRepositary()
        {
            return new OutPatientRepositary();
        }


        #endregion

        #region Other Action Methods



        #endregion

        #region Business Methods
        #region GetMaxOutPatientId
        [HttpPost]
        public virtual ActionResult GetMaxOutPatientId()
        {
            try
            {
                var result = OutPatientRepositary().GetMaxOutPatientId();

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return returnNull;
        }
        #endregion
        #region bindGenerateBarcode
        [HttpPost]
        public virtual ActionResult GenerateBarcode()
        {
            string barcodeimg = "";
            try
            {

                string YY = Convert.ToString(System.DateTime.Now.Year).Substring(2, 2);
                string DD = Convert.ToString(System.DateTime.Now.Day);
                var result = OutPatientRepositary().GetMaxOutPatientId();
                string barcode = YY + DD + result;
                using (MemoryStream ms = new MemoryStream())
                {
                    //The Image is drawn based on length of Barcode text.
                    using (Bitmap bitMap = new Bitmap(barcode.Length * 30, 80))
                    {
                        //The Graphics library object is generated for the Image.
                        using (Graphics graphics = Graphics.FromImage(bitMap))
                        {
                            //The installed Barcode font.
                            Font oFont = new Font("IDAutomationHC39M Free Version", 16);
                            PointF point = new PointF(2f, 2f);

                            //White Brush is used to fill the Image with white color.
                            SolidBrush whiteBrush = new SolidBrush(Color.White);
                            graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                            //Black Brush is used to draw the Barcode over the Image.
                            SolidBrush blackBrush = new SolidBrush(Color.Black);
                            graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                        }

                        //The Bitmap is saved to Memory Stream.
                        bitMap.Save(ms, ImageFormat.Png);

                        TempData["barcodeImg"] = ms.ToArray();
                        TempData.Keep("barcodeImg");
                        barcodeimg = Convert.ToBase64String(ms.ToArray());

                    }

                }
                var jsonResult = Json(barcodeimg, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return returnNull;
        }


        #endregion

        #region GetOutPatientDepartmentDetails
        [HttpPost]
        public virtual ActionResult GetOutPatientDepartmentDetails()
        {
            try
            {
                var result = OutPatientRepositary().GetOutPatientDepartmentDetails();

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
            }
            return returnNull;

        }
        #endregion

        #region CRUDDepotMasterDetails
        [HttpPost]
        public virtual ActionResult CRUDOPRegistrationDetails(OutPatientModal.OutPatientRegistration outPatientRegistration)
        {
            try
            {
                outPatientRegistration.Barcode_Image = (byte[])TempData["barcodeImg"];
               
                var result = OutPatientRepositary().CRUDOPRegistrationDetails(outPatientRegistration);

                var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return returnNull;
        }
        #endregion
        #endregion
    }
}