// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: content/controls/closed_vector_controls.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DesignModel.ContentTypes.Controls {

  /// <summary>Holder for reflection information generated from content/controls/closed_vector_controls.proto</summary>
  public static partial class ClosedVectorControlsReflection {

    #region Descriptor
    /// <summary>File descriptor for content/controls/closed_vector_controls.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ClosedVectorControlsReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ci1jb250ZW50L2NvbnRyb2xzL2Nsb3NlZF92ZWN0b3JfY29udHJvbHMucHJv",
            "dG8SF2Rlc2lnbi5jb250ZW50LmNvbnRyb2xzGiljb250ZW50L2NvbnRyb2xz",
            "L3JlY3RhbmdsZV9jb250cm9scy5wcm90bxokY29udGVudC9jb250cm9scy9w",
            "YXRoX2NvbnRyb2xzLnByb3RvIroBChRDbG9zZWRWZWN0b3JDb250cm9scxJI",
            "ChJyZWN0YW5nbGVfY29udHJvbHMYASABKAsyKi5kZXNpZ24uY29udGVudC5j",
            "b250cm9scy5SZWN0YW5nbGVDb250cm9sc0gAEj4KDXBhdGhfY29udHJvbHMY",
            "AiABKAsyJS5kZXNpZ24uY29udGVudC5jb250cm9scy5QYXRoQ29udHJvbHNI",
            "AEIYChZjbG9zZWRfdmVjdG9yX2NvbnRyb2xzQiSqAiFEZXNpZ25Nb2RlbC5D",
            "b250ZW50VHlwZXMuQ29udHJvbHNiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::DesignModel.ContentTypes.Controls.RectangleControlsReflection.Descriptor, global::DesignModel.ContentTypes.Controls.PathControlsReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DesignModel.ContentTypes.Controls.ClosedVectorControls), global::DesignModel.ContentTypes.Controls.ClosedVectorControls.Parser, new[]{ "RectangleControls", "PathControls" }, new[]{ "ClosedVectorControls" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class ClosedVectorControls : pb::IMessage<ClosedVectorControls>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<ClosedVectorControls> _parser = new pb::MessageParser<ClosedVectorControls>(() => new ClosedVectorControls());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<ClosedVectorControls> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DesignModel.ContentTypes.Controls.ClosedVectorControlsReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ClosedVectorControls() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ClosedVectorControls(ClosedVectorControls other) : this() {
      switch (other.ClosedVectorControlsCase) {
        case ClosedVectorControlsOneofCase.RectangleControls:
          RectangleControls = other.RectangleControls.Clone();
          break;
        case ClosedVectorControlsOneofCase.PathControls:
          PathControls = other.PathControls.Clone();
          break;
      }

      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ClosedVectorControls Clone() {
      return new ClosedVectorControls(this);
    }

    /// <summary>Field number for the "rectangle_controls" field.</summary>
    public const int RectangleControlsFieldNumber = 1;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::DesignModel.ContentTypes.Controls.RectangleControls RectangleControls {
      get { return closedVectorControlsCase_ == ClosedVectorControlsOneofCase.RectangleControls ? (global::DesignModel.ContentTypes.Controls.RectangleControls) closedVectorControls_ : null; }
      set {
        closedVectorControls_ = value;
        closedVectorControlsCase_ = value == null ? ClosedVectorControlsOneofCase.None : ClosedVectorControlsOneofCase.RectangleControls;
      }
    }

    /// <summary>Field number for the "path_controls" field.</summary>
    public const int PathControlsFieldNumber = 2;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::DesignModel.ContentTypes.Controls.PathControls PathControls {
      get { return closedVectorControlsCase_ == ClosedVectorControlsOneofCase.PathControls ? (global::DesignModel.ContentTypes.Controls.PathControls) closedVectorControls_ : null; }
      set {
        closedVectorControls_ = value;
        closedVectorControlsCase_ = value == null ? ClosedVectorControlsOneofCase.None : ClosedVectorControlsOneofCase.PathControls;
      }
    }

    private object closedVectorControls_;
    /// <summary>Enum of possible cases for the "closed_vector_controls" oneof.</summary>
    public enum ClosedVectorControlsOneofCase {
      None = 0,
      RectangleControls = 1,
      PathControls = 2,
    }
    private ClosedVectorControlsOneofCase closedVectorControlsCase_ = ClosedVectorControlsOneofCase.None;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public ClosedVectorControlsOneofCase ClosedVectorControlsCase {
      get { return closedVectorControlsCase_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void ClearClosedVectorControls() {
      closedVectorControlsCase_ = ClosedVectorControlsOneofCase.None;
      closedVectorControls_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as ClosedVectorControls);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(ClosedVectorControls other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(RectangleControls, other.RectangleControls)) return false;
      if (!object.Equals(PathControls, other.PathControls)) return false;
      if (ClosedVectorControlsCase != other.ClosedVectorControlsCase) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.RectangleControls) hash ^= RectangleControls.GetHashCode();
      if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.PathControls) hash ^= PathControls.GetHashCode();
      hash ^= (int) closedVectorControlsCase_;
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.RectangleControls) {
        output.WriteRawTag(10);
        output.WriteMessage(RectangleControls);
      }
      if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.PathControls) {
        output.WriteRawTag(18);
        output.WriteMessage(PathControls);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.RectangleControls) {
        output.WriteRawTag(10);
        output.WriteMessage(RectangleControls);
      }
      if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.PathControls) {
        output.WriteRawTag(18);
        output.WriteMessage(PathControls);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.RectangleControls) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(RectangleControls);
      }
      if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.PathControls) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(PathControls);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(ClosedVectorControls other) {
      if (other == null) {
        return;
      }
      switch (other.ClosedVectorControlsCase) {
        case ClosedVectorControlsOneofCase.RectangleControls:
          if (RectangleControls == null) {
            RectangleControls = new global::DesignModel.ContentTypes.Controls.RectangleControls();
          }
          RectangleControls.MergeFrom(other.RectangleControls);
          break;
        case ClosedVectorControlsOneofCase.PathControls:
          if (PathControls == null) {
            PathControls = new global::DesignModel.ContentTypes.Controls.PathControls();
          }
          PathControls.MergeFrom(other.PathControls);
          break;
      }

      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            global::DesignModel.ContentTypes.Controls.RectangleControls subBuilder = new global::DesignModel.ContentTypes.Controls.RectangleControls();
            if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.RectangleControls) {
              subBuilder.MergeFrom(RectangleControls);
            }
            input.ReadMessage(subBuilder);
            RectangleControls = subBuilder;
            break;
          }
          case 18: {
            global::DesignModel.ContentTypes.Controls.PathControls subBuilder = new global::DesignModel.ContentTypes.Controls.PathControls();
            if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.PathControls) {
              subBuilder.MergeFrom(PathControls);
            }
            input.ReadMessage(subBuilder);
            PathControls = subBuilder;
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            global::DesignModel.ContentTypes.Controls.RectangleControls subBuilder = new global::DesignModel.ContentTypes.Controls.RectangleControls();
            if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.RectangleControls) {
              subBuilder.MergeFrom(RectangleControls);
            }
            input.ReadMessage(subBuilder);
            RectangleControls = subBuilder;
            break;
          }
          case 18: {
            global::DesignModel.ContentTypes.Controls.PathControls subBuilder = new global::DesignModel.ContentTypes.Controls.PathControls();
            if (closedVectorControlsCase_ == ClosedVectorControlsOneofCase.PathControls) {
              subBuilder.MergeFrom(PathControls);
            }
            input.ReadMessage(subBuilder);
            PathControls = subBuilder;
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
