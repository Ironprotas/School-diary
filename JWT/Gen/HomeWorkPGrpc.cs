// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: HomeWorkP.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace HomewWork {
  public static partial class HomeWorkService
  {
    static readonly string __ServiceName = "homew_work.HomeWorkService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.AddHomeWorkRequest> __Marshaller_homew_work_AddHomeWorkRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.AddHomeWorkRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.AddHomeWorkResponse> __Marshaller_homew_work_AddHomeWorkResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.AddHomeWorkResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.GetHomeWorkRequest> __Marshaller_homew_work_GetHomeWorkRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.GetHomeWorkRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.GetHomeWorkResponse> __Marshaller_homew_work_GetHomeWorkResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.GetHomeWorkResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.GetHomeUserRequest> __Marshaller_homew_work_GetHomeUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.GetHomeUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.GetHomeUserResponse> __Marshaller_homew_work_GetHomeUserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.GetHomeUserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.GetHomeWorkParentRequest> __Marshaller_homew_work_GetHomeWorkParentRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.GetHomeWorkParentRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.GetHomeWorkParentResponse> __Marshaller_homew_work_GetHomeWorkParentResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.GetHomeWorkParentResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.DeleteHomeWorkRequest> __Marshaller_homew_work_DeleteHomeWorkRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.DeleteHomeWorkRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::HomewWork.EditHomeWorkRequest> __Marshaller_homew_work_EditHomeWorkRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::HomewWork.EditHomeWorkRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HomewWork.AddHomeWorkRequest, global::HomewWork.AddHomeWorkResponse> __Method_AddHomeWork = new grpc::Method<global::HomewWork.AddHomeWorkRequest, global::HomewWork.AddHomeWorkResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddHomeWork",
        __Marshaller_homew_work_AddHomeWorkRequest,
        __Marshaller_homew_work_AddHomeWorkResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HomewWork.GetHomeWorkRequest, global::HomewWork.GetHomeWorkResponse> __Method_GetHomeWork = new grpc::Method<global::HomewWork.GetHomeWorkRequest, global::HomewWork.GetHomeWorkResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetHomeWork",
        __Marshaller_homew_work_GetHomeWorkRequest,
        __Marshaller_homew_work_GetHomeWorkResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HomewWork.GetHomeUserRequest, global::HomewWork.GetHomeUserResponse> __Method_GetHomeUser = new grpc::Method<global::HomewWork.GetHomeUserRequest, global::HomewWork.GetHomeUserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetHomeUser",
        __Marshaller_homew_work_GetHomeUserRequest,
        __Marshaller_homew_work_GetHomeUserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HomewWork.GetHomeWorkParentRequest, global::HomewWork.GetHomeWorkParentResponse> __Method_GetHomeWorkParent = new grpc::Method<global::HomewWork.GetHomeWorkParentRequest, global::HomewWork.GetHomeWorkParentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetHomeWorkParent",
        __Marshaller_homew_work_GetHomeWorkParentRequest,
        __Marshaller_homew_work_GetHomeWorkParentResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HomewWork.DeleteHomeWorkRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_DeleteHomeWork = new grpc::Method<global::HomewWork.DeleteHomeWorkRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteHomeWork",
        __Marshaller_homew_work_DeleteHomeWorkRequest,
        __Marshaller_google_protobuf_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::HomewWork.EditHomeWorkRequest, global::Google.Protobuf.WellKnownTypes.Empty> __Method_EditHomeWork = new grpc::Method<global::HomewWork.EditHomeWorkRequest, global::Google.Protobuf.WellKnownTypes.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "EditHomeWork",
        __Marshaller_homew_work_EditHomeWorkRequest,
        __Marshaller_google_protobuf_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::HomewWork.HomeWorkPReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of HomeWorkService</summary>
    [grpc::BindServiceMethod(typeof(HomeWorkService), "BindService")]
    public abstract partial class HomeWorkServiceBase
    {
      /// <summary>
      /// Добавление ДЗ
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::HomewWork.AddHomeWorkResponse> AddHomeWork(global::HomewWork.AddHomeWorkRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Получение ДЗ
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::HomewWork.GetHomeWorkResponse> GetHomeWork(global::HomewWork.GetHomeWorkRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Получение ДЗ пользователя
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::HomewWork.GetHomeUserResponse> GetHomeUser(global::HomewWork.GetHomeUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Получение ДЗ ребенка
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::HomewWork.GetHomeWorkParentResponse> GetHomeWorkParent(global::HomewWork.GetHomeWorkParentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Удаление ДЗ
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> DeleteHomeWork(global::HomewWork.DeleteHomeWorkRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      /// <summary>
      /// Редактирование ДЗ
      /// </summary>
      /// <param name="request">The request received from the client.</param>
      /// <param name="context">The context of the server-side call handler being invoked.</param>
      /// <returns>The response to send back to the client (wrapped by a task).</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Google.Protobuf.WellKnownTypes.Empty> EditHomeWork(global::HomewWork.EditHomeWorkRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for HomeWorkService</summary>
    public partial class HomeWorkServiceClient : grpc::ClientBase<HomeWorkServiceClient>
    {
      /// <summary>Creates a new client for HomeWorkService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public HomeWorkServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for HomeWorkService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public HomeWorkServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected HomeWorkServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected HomeWorkServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      /// <summary>
      /// Добавление ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HomewWork.AddHomeWorkResponse AddHomeWork(global::HomewWork.AddHomeWorkRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddHomeWork(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Добавление ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HomewWork.AddHomeWorkResponse AddHomeWork(global::HomewWork.AddHomeWorkRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddHomeWork, null, options, request);
      }
      /// <summary>
      /// Добавление ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HomewWork.AddHomeWorkResponse> AddHomeWorkAsync(global::HomewWork.AddHomeWorkRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddHomeWorkAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Добавление ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HomewWork.AddHomeWorkResponse> AddHomeWorkAsync(global::HomewWork.AddHomeWorkRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddHomeWork, null, options, request);
      }
      /// <summary>
      /// Получение ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HomewWork.GetHomeWorkResponse GetHomeWork(global::HomewWork.GetHomeWorkRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetHomeWork(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Получение ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HomewWork.GetHomeWorkResponse GetHomeWork(global::HomewWork.GetHomeWorkRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetHomeWork, null, options, request);
      }
      /// <summary>
      /// Получение ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HomewWork.GetHomeWorkResponse> GetHomeWorkAsync(global::HomewWork.GetHomeWorkRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetHomeWorkAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Получение ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HomewWork.GetHomeWorkResponse> GetHomeWorkAsync(global::HomewWork.GetHomeWorkRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetHomeWork, null, options, request);
      }
      /// <summary>
      /// Получение ДЗ пользователя
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HomewWork.GetHomeUserResponse GetHomeUser(global::HomewWork.GetHomeUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetHomeUser(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Получение ДЗ пользователя
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HomewWork.GetHomeUserResponse GetHomeUser(global::HomewWork.GetHomeUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetHomeUser, null, options, request);
      }
      /// <summary>
      /// Получение ДЗ пользователя
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HomewWork.GetHomeUserResponse> GetHomeUserAsync(global::HomewWork.GetHomeUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetHomeUserAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Получение ДЗ пользователя
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HomewWork.GetHomeUserResponse> GetHomeUserAsync(global::HomewWork.GetHomeUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetHomeUser, null, options, request);
      }
      /// <summary>
      /// Получение ДЗ ребенка
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HomewWork.GetHomeWorkParentResponse GetHomeWorkParent(global::HomewWork.GetHomeWorkParentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetHomeWorkParent(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Получение ДЗ ребенка
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::HomewWork.GetHomeWorkParentResponse GetHomeWorkParent(global::HomewWork.GetHomeWorkParentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetHomeWorkParent, null, options, request);
      }
      /// <summary>
      /// Получение ДЗ ребенка
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HomewWork.GetHomeWorkParentResponse> GetHomeWorkParentAsync(global::HomewWork.GetHomeWorkParentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetHomeWorkParentAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Получение ДЗ ребенка
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::HomewWork.GetHomeWorkParentResponse> GetHomeWorkParentAsync(global::HomewWork.GetHomeWorkParentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetHomeWorkParent, null, options, request);
      }
      /// <summary>
      /// Удаление ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteHomeWork(global::HomewWork.DeleteHomeWorkRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteHomeWork(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Удаление ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty DeleteHomeWork(global::HomewWork.DeleteHomeWorkRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteHomeWork, null, options, request);
      }
      /// <summary>
      /// Удаление ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteHomeWorkAsync(global::HomewWork.DeleteHomeWorkRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteHomeWorkAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Удаление ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> DeleteHomeWorkAsync(global::HomewWork.DeleteHomeWorkRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteHomeWork, null, options, request);
      }
      /// <summary>
      /// Редактирование ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty EditHomeWork(global::HomewWork.EditHomeWorkRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return EditHomeWork(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Редактирование ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The response received from the server.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Google.Protobuf.WellKnownTypes.Empty EditHomeWork(global::HomewWork.EditHomeWorkRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_EditHomeWork, null, options, request);
      }
      /// <summary>
      /// Редактирование ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="headers">The initial metadata to send with the call. This parameter is optional.</param>
      /// <param name="deadline">An optional deadline for the call. The call will be cancelled if deadline is hit.</param>
      /// <param name="cancellationToken">An optional token for canceling the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> EditHomeWorkAsync(global::HomewWork.EditHomeWorkRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return EditHomeWorkAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      /// <summary>
      /// Редактирование ДЗ
      /// </summary>
      /// <param name="request">The request to send to the server.</param>
      /// <param name="options">The options for the call.</param>
      /// <returns>The call object.</returns>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Google.Protobuf.WellKnownTypes.Empty> EditHomeWorkAsync(global::HomewWork.EditHomeWorkRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_EditHomeWork, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override HomeWorkServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new HomeWorkServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(HomeWorkServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_AddHomeWork, serviceImpl.AddHomeWork)
          .AddMethod(__Method_GetHomeWork, serviceImpl.GetHomeWork)
          .AddMethod(__Method_GetHomeUser, serviceImpl.GetHomeUser)
          .AddMethod(__Method_GetHomeWorkParent, serviceImpl.GetHomeWorkParent)
          .AddMethod(__Method_DeleteHomeWork, serviceImpl.DeleteHomeWork)
          .AddMethod(__Method_EditHomeWork, serviceImpl.EditHomeWork).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, HomeWorkServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_AddHomeWork, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HomewWork.AddHomeWorkRequest, global::HomewWork.AddHomeWorkResponse>(serviceImpl.AddHomeWork));
      serviceBinder.AddMethod(__Method_GetHomeWork, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HomewWork.GetHomeWorkRequest, global::HomewWork.GetHomeWorkResponse>(serviceImpl.GetHomeWork));
      serviceBinder.AddMethod(__Method_GetHomeUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HomewWork.GetHomeUserRequest, global::HomewWork.GetHomeUserResponse>(serviceImpl.GetHomeUser));
      serviceBinder.AddMethod(__Method_GetHomeWorkParent, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HomewWork.GetHomeWorkParentRequest, global::HomewWork.GetHomeWorkParentResponse>(serviceImpl.GetHomeWorkParent));
      serviceBinder.AddMethod(__Method_DeleteHomeWork, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HomewWork.DeleteHomeWorkRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.DeleteHomeWork));
      serviceBinder.AddMethod(__Method_EditHomeWork, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::HomewWork.EditHomeWorkRequest, global::Google.Protobuf.WellKnownTypes.Empty>(serviceImpl.EditHomeWork));
    }

  }
}
#endregion
