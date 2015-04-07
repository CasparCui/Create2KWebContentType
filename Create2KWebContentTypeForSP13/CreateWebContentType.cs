using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace Create2KWebContentTypeForSP13
{
    public class CreateWebContentType:IDisposable
    {
        private SPWeb web;
        public CreateWebContentType(String webUrl)
        {
            using (SPSite _site = new SPSite(webUrl))
            {
                using (SPWeb _web = _site.OpenWeb())
                {
                    this.web = _web;
                }
            }
        }
        public void CreateContentType(string spContentTypeName)
        {
            var contentTypeCollection = this.web.ContentTypes;
            if (contentTypeCollection.Count > 0)
            {
                SPContentType contentType = new SPContentType(contentTypeCollection[0], contentTypeCollection, spContentTypeName);
                contentTypeCollection.Add(contentType);
            }
        }
        public void Update()
        {
            this.web.Update();
        }
        ~CreateWebContentType()
        {
            this.web.Dispose();
        }


        #region IDisposable Members

        public void Dispose()
        {
            this.web.Dispose();
        }

        #endregion
    }
}
