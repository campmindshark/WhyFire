using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WhyRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWhyService" in both code and config file together.
    [ServiceContract]
    public interface IWhyService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects")]
        List<Effect> GetFXList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml,
                                BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/{id}")]
        Effect GetFx(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/{id}/fire")]
        string Fire(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/sweepleft")]
        string sweepLeft();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/sweepright")]
        string sweepRight();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/alternate")]
        string alternate();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/winston")]
        string winston();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/rollcall")]
        string rollcall();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/middlefinger")]
        string middlefinger();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/stayout")]
        string stayout();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/ynot")]
        string ynot();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Effects/all")]
        string all();

    }
}
