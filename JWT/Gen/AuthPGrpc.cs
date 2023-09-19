// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: AuthP.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Auth {
  public static partial class MainService
  {
    static readonly string __ServiceName = "auth.MainService";

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
    static readonly grpc::Marshaller<global::Auth.RegisterUserRequest> __Marshaller_auth_RegisterUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.RegisterUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.RegisterUserResponse> __Marshaller_auth_RegisterUserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.RegisterUserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.LoginUserRequest> __Marshaller_auth_LoginUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.LoginUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.LoginUserResponse> __Marshaller_auth_LoginUserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.LoginUserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.EditUserRequest> __Marshaller_auth_EditUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.EditUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.EditUserResponse> __Marshaller_auth_EditUserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.EditUserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.GetUserInfoRequest> __Marshaller_auth_GetUserInfoRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.GetUserInfoRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.GetUserInfoResponse> __Marshaller_auth_GetUserInfoResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.GetUserInfoResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.DeleteUserRequest> __Marshaller_auth_DeleteUserRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.DeleteUserRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.DeleteUserResponse> __Marshaller_auth_DeleteUserResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.DeleteUserResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.AddParentToStudentRequest> __Marshaller_auth_AddParentToStudentRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.AddParentToStudentRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.AddParentToStudentResponse> __Marshaller_auth_AddParentToStudentResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.AddParentToStudentResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.RemoveStudentFromParentRequest> __Marshaller_auth_RemoveStudentFromParentRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.RemoveStudentFromParentRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Auth.RemoveStudentFromParentResponse> __Marshaller_auth_RemoveStudentFromParentResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Auth.RemoveStudentFromParentResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Auth.RegisterUserRequest, global::Auth.RegisterUserResponse> __Method_RegisterUser = new grpc::Method<global::Auth.RegisterUserRequest, global::Auth.RegisterUserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RegisterUser",
        __Marshaller_auth_RegisterUserRequest,
        __Marshaller_auth_RegisterUserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Auth.LoginUserRequest, global::Auth.LoginUserResponse> __Method_LoginUser = new grpc::Method<global::Auth.LoginUserRequest, global::Auth.LoginUserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "LoginUser",
        __Marshaller_auth_LoginUserRequest,
        __Marshaller_auth_LoginUserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Auth.EditUserRequest, global::Auth.EditUserResponse> __Method_EditUser = new grpc::Method<global::Auth.EditUserRequest, global::Auth.EditUserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "EditUser",
        __Marshaller_auth_EditUserRequest,
        __Marshaller_auth_EditUserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Auth.GetUserInfoRequest, global::Auth.GetUserInfoResponse> __Method_GetUserInfo = new grpc::Method<global::Auth.GetUserInfoRequest, global::Auth.GetUserInfoResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUserInfo",
        __Marshaller_auth_GetUserInfoRequest,
        __Marshaller_auth_GetUserInfoResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Auth.DeleteUserRequest, global::Auth.DeleteUserResponse> __Method_DeleteUser = new grpc::Method<global::Auth.DeleteUserRequest, global::Auth.DeleteUserResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteUser",
        __Marshaller_auth_DeleteUserRequest,
        __Marshaller_auth_DeleteUserResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Auth.AddParentToStudentRequest, global::Auth.AddParentToStudentResponse> __Method_AddParentToStudent = new grpc::Method<global::Auth.AddParentToStudentRequest, global::Auth.AddParentToStudentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddParentToStudent",
        __Marshaller_auth_AddParentToStudentRequest,
        __Marshaller_auth_AddParentToStudentResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Auth.RemoveStudentFromParentRequest, global::Auth.RemoveStudentFromParentResponse> __Method_RemoveStudentFromParent = new grpc::Method<global::Auth.RemoveStudentFromParentRequest, global::Auth.RemoveStudentFromParentResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RemoveStudentFromParent",
        __Marshaller_auth_RemoveStudentFromParentRequest,
        __Marshaller_auth_RemoveStudentFromParentResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Auth.AuthPReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of MainService</summary>
    [grpc::BindServiceMethod(typeof(MainService), "BindService")]
    public abstract partial class MainServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Auth.RegisterUserResponse> RegisterUser(global::Auth.RegisterUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Auth.LoginUserResponse> LoginUser(global::Auth.LoginUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Auth.EditUserResponse> EditUser(global::Auth.EditUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Auth.GetUserInfoResponse> GetUserInfo(global::Auth.GetUserInfoRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Auth.DeleteUserResponse> DeleteUser(global::Auth.DeleteUserRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Auth.AddParentToStudentResponse> AddParentToStudent(global::Auth.AddParentToStudentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Auth.RemoveStudentFromParentResponse> RemoveStudentFromParent(global::Auth.RemoveStudentFromParentRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for MainService</summary>
    public partial class MainServiceClient : grpc::ClientBase<MainServiceClient>
    {
      /// <summary>Creates a new client for MainService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public MainServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for MainService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public MainServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected MainServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected MainServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.RegisterUserResponse RegisterUser(global::Auth.RegisterUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegisterUser(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.RegisterUserResponse RegisterUser(global::Auth.RegisterUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RegisterUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.RegisterUserResponse> RegisterUserAsync(global::Auth.RegisterUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RegisterUserAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.RegisterUserResponse> RegisterUserAsync(global::Auth.RegisterUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RegisterUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.LoginUserResponse LoginUser(global::Auth.LoginUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LoginUser(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.LoginUserResponse LoginUser(global::Auth.LoginUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_LoginUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.LoginUserResponse> LoginUserAsync(global::Auth.LoginUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return LoginUserAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.LoginUserResponse> LoginUserAsync(global::Auth.LoginUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_LoginUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.EditUserResponse EditUser(global::Auth.EditUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return EditUser(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.EditUserResponse EditUser(global::Auth.EditUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_EditUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.EditUserResponse> EditUserAsync(global::Auth.EditUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return EditUserAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.EditUserResponse> EditUserAsync(global::Auth.EditUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_EditUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.GetUserInfoResponse GetUserInfo(global::Auth.GetUserInfoRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetUserInfo(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.GetUserInfoResponse GetUserInfo(global::Auth.GetUserInfoRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetUserInfo, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.GetUserInfoResponse> GetUserInfoAsync(global::Auth.GetUserInfoRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetUserInfoAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.GetUserInfoResponse> GetUserInfoAsync(global::Auth.GetUserInfoRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetUserInfo, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.DeleteUserResponse DeleteUser(global::Auth.DeleteUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteUser(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.DeleteUserResponse DeleteUser(global::Auth.DeleteUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_DeleteUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.DeleteUserResponse> DeleteUserAsync(global::Auth.DeleteUserRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteUserAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.DeleteUserResponse> DeleteUserAsync(global::Auth.DeleteUserRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_DeleteUser, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.AddParentToStudentResponse AddParentToStudent(global::Auth.AddParentToStudentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddParentToStudent(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.AddParentToStudentResponse AddParentToStudent(global::Auth.AddParentToStudentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_AddParentToStudent, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.AddParentToStudentResponse> AddParentToStudentAsync(global::Auth.AddParentToStudentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return AddParentToStudentAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.AddParentToStudentResponse> AddParentToStudentAsync(global::Auth.AddParentToStudentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_AddParentToStudent, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.RemoveStudentFromParentResponse RemoveStudentFromParent(global::Auth.RemoveStudentFromParentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveStudentFromParent(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Auth.RemoveStudentFromParentResponse RemoveStudentFromParent(global::Auth.RemoveStudentFromParentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RemoveStudentFromParent, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.RemoveStudentFromParentResponse> RemoveStudentFromParentAsync(global::Auth.RemoveStudentFromParentRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return RemoveStudentFromParentAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Auth.RemoveStudentFromParentResponse> RemoveStudentFromParentAsync(global::Auth.RemoveStudentFromParentRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RemoveStudentFromParent, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override MainServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MainServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(MainServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_RegisterUser, serviceImpl.RegisterUser)
          .AddMethod(__Method_LoginUser, serviceImpl.LoginUser)
          .AddMethod(__Method_EditUser, serviceImpl.EditUser)
          .AddMethod(__Method_GetUserInfo, serviceImpl.GetUserInfo)
          .AddMethod(__Method_DeleteUser, serviceImpl.DeleteUser)
          .AddMethod(__Method_AddParentToStudent, serviceImpl.AddParentToStudent)
          .AddMethod(__Method_RemoveStudentFromParent, serviceImpl.RemoveStudentFromParent).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, MainServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_RegisterUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Auth.RegisterUserRequest, global::Auth.RegisterUserResponse>(serviceImpl.RegisterUser));
      serviceBinder.AddMethod(__Method_LoginUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Auth.LoginUserRequest, global::Auth.LoginUserResponse>(serviceImpl.LoginUser));
      serviceBinder.AddMethod(__Method_EditUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Auth.EditUserRequest, global::Auth.EditUserResponse>(serviceImpl.EditUser));
      serviceBinder.AddMethod(__Method_GetUserInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Auth.GetUserInfoRequest, global::Auth.GetUserInfoResponse>(serviceImpl.GetUserInfo));
      serviceBinder.AddMethod(__Method_DeleteUser, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Auth.DeleteUserRequest, global::Auth.DeleteUserResponse>(serviceImpl.DeleteUser));
      serviceBinder.AddMethod(__Method_AddParentToStudent, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Auth.AddParentToStudentRequest, global::Auth.AddParentToStudentResponse>(serviceImpl.AddParentToStudent));
      serviceBinder.AddMethod(__Method_RemoveStudentFromParent, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Auth.RemoveStudentFromParentRequest, global::Auth.RemoveStudentFromParentResponse>(serviceImpl.RemoveStudentFromParent));
    }

  }
}
#endregion
