// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: math/sides.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace DesignModel.MathTypes {

  /// <summary>Holder for reflection information generated from math/sides.proto</summary>
  public static partial class SidesReflection {

    #region Descriptor
    /// <summary>File descriptor for math/sides.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static SidesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBtYXRoL3NpZGVzLnByb3RvEgtkZXNpZ24ubWF0aCJBCgVTaWRlcxIMCgRs",
            "ZWZ0GAEgASgCEgsKA3RvcBgCIAEoAhINCgVyaWdodBgDIAEoAhIOCgZib3R0",
            "b20YBCABKAJCGKoCFURlc2lnbk1vZGVsLk1hdGhUeXBlc2IGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::DesignModel.MathTypes.Sides), global::DesignModel.MathTypes.Sides.Parser, new[]{ "Left", "Top", "Right", "Bottom" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Sides : pb::IMessage<Sides>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Sides> _parser = new pb::MessageParser<Sides>(() => new Sides());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Sides> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::DesignModel.MathTypes.SidesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Sides() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Sides(Sides other) : this() {
      left_ = other.left_;
      top_ = other.top_;
      right_ = other.right_;
      bottom_ = other.bottom_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Sides Clone() {
      return new Sides(this);
    }

    /// <summary>Field number for the "left" field.</summary>
    public const int LeftFieldNumber = 1;
    private float left_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float Left {
      get { return left_; }
      set {
        left_ = value;
      }
    }

    /// <summary>Field number for the "top" field.</summary>
    public const int TopFieldNumber = 2;
    private float top_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float Top {
      get { return top_; }
      set {
        top_ = value;
      }
    }

    /// <summary>Field number for the "right" field.</summary>
    public const int RightFieldNumber = 3;
    private float right_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float Right {
      get { return right_; }
      set {
        right_ = value;
      }
    }

    /// <summary>Field number for the "bottom" field.</summary>
    public const int BottomFieldNumber = 4;
    private float bottom_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public float Bottom {
      get { return bottom_; }
      set {
        bottom_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Sides);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Sides other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Left, other.Left)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Top, other.Top)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Right, other.Right)) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Bottom, other.Bottom)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (Left != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Left);
      if (Top != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Top);
      if (Right != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Right);
      if (Bottom != 0F) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Bottom);
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
      if (Left != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(Left);
      }
      if (Top != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(Top);
      }
      if (Right != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(Right);
      }
      if (Bottom != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(Bottom);
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
      if (Left != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(Left);
      }
      if (Top != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(Top);
      }
      if (Right != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(Right);
      }
      if (Bottom != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(Bottom);
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
      if (Left != 0F) {
        size += 1 + 4;
      }
      if (Top != 0F) {
        size += 1 + 4;
      }
      if (Right != 0F) {
        size += 1 + 4;
      }
      if (Bottom != 0F) {
        size += 1 + 4;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Sides other) {
      if (other == null) {
        return;
      }
      if (other.Left != 0F) {
        Left = other.Left;
      }
      if (other.Top != 0F) {
        Top = other.Top;
      }
      if (other.Right != 0F) {
        Right = other.Right;
      }
      if (other.Bottom != 0F) {
        Bottom = other.Bottom;
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
          case 13: {
            Left = input.ReadFloat();
            break;
          }
          case 21: {
            Top = input.ReadFloat();
            break;
          }
          case 29: {
            Right = input.ReadFloat();
            break;
          }
          case 37: {
            Bottom = input.ReadFloat();
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
          case 13: {
            Left = input.ReadFloat();
            break;
          }
          case 21: {
            Top = input.ReadFloat();
            break;
          }
          case 29: {
            Right = input.ReadFloat();
            break;
          }
          case 37: {
            Bottom = input.ReadFloat();
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
