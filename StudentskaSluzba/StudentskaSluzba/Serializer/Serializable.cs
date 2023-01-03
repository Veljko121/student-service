namespace StudentskaSluzba.Serializer
{
    internal interface ISerializable
    {
        string[] ToCSV();

        void FromCSV(string[] values);
    }
}
