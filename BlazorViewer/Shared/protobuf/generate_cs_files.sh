full_path=$(realpath $0)

dir_path=$(dirname $full_path)

mkdir -p $dir_path/DesignModel

protoc -I=$dir_path/design --csharp_out=$dir_path/DesignModel --csharp_opt=file_extension=.g.cs,base_namespace=DesignModel $dir_path/design/*.proto $dir_path/design/math/*.proto $dir_path/design/appearance/*.proto $dir_path/design/content/controls/*.proto $dir_path/design/content/*.proto

read