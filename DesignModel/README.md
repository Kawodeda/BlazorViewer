# Design Model (Protobuf)

## Content

- [About](#about)
- [Prerequisites](#prerequisites)
- [Usage](#usage)

## About <a name = "about"></a>

Here's the first version of [The model of "design"](./%D0%9C%D0%BE%D0%B4%D0%B5%D0%BB%D1%8C%20%D0%B4%D0%B8%D0%B7%D0%B0%D0%B9%D0%BD%D0%B0%20-%20Overview.pdf) described via Google's Protobuf. All `.proto` are in the [design](./design/) folder.

## Prerequisites <a name = "prerequisites"></a>

In order to generate C# code from these `.proto` you need to install Proto Buffer compiler (`protoc`).
Here's [the latest `protoc` relese](https://github.com/protocolbuffers/protobuf/releases/).

## Usage <a name = "usage"></a>

In order to generate C# code you need to:
1. run generate_cs_files.sh

After that, the DesignModel directory will be automatically created with all the `.g.cs` file corresponding to the `.proto` files from the [design](./design/) folder.\
Note: the `.g.cs` extension means automatically generated C# code. 
