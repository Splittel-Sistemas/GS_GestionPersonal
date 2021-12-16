using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Helpers
{
    public class ApiException: Exception
    {
        public EnumStatusCodes StatusCodes { get; private set; }

        public ApiException(EnumStatusCodes enumStatus)
        {
            StatusCodes = enumStatus;
        }

        public ApiException(string mensaje, EnumStatusCodes enumStatus)
            : base(mensaje)
        {
            StatusCodes = enumStatus;
        }
    }
    public enum EnumStatusCodes
    {
        Continue = 100,
        PreconditionFailed = 412,
        PayloadTooLarge = 413,
        RequestEntityTooLarge = 413,
        RequestUriTooLong = 414,
        UriTooLong = 414,
        UnsupportedMediaType = 415,
        RangeNotSatisfiable = 416,
        RequestedRangeNotSatisfiable = 416,
        ExpectationFailed = 417,
        ImATeapot = 418,
        AuthenticationTimeout = 419,
        MisdirectedRequest = 421,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        TooManyRequests = 429,
        RequestHeaderFieldsTooLarge = 431,
        UnavailableForLegalReasons = 451,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
        ServiceUnavailable = 503,
        GatewayTimeout = 504,
        HttpVersionNotsupported = 505,
        VariantAlsoNegotiates = 506,
        InsufficientStorage = 507,
        LoopDetected = 508,
        LengthRequired = 411,
        NotExtended = 510,
        Gone = 410,
        RequestTimeout = 408,
        SwitchingProtocols = 101,
        Processing = 102,
        OK = 200,
        Created = 201,
        Accepted = 202,
        NonAuthoritative = 203,
        NoContent = 204,
        ResetContent = 205,
        PartialContent = 206,
        MultiStatus = 207,
        AlreadyReported = 208,
        IMUsed = 226,
        MultipleChoices = 300,
        MovedPermanently = 301,
        Found = 302,
        SeeOther = 303,
        NotModified = 304,
        UseProxy = 305,
        SwitchProxy = 306,
        TemporaryRedirect = 307,
        PermanentRedirect = 308,
        BadRequest = 400,
        Unauthorized = 401,
        PaymentRequired = 402,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        NotAcceptable = 406,
        ProxyAuthenticationRequired = 407,
        Conflict = 409,
        NetworkAuthenticationRequired = 511,
    }
}
