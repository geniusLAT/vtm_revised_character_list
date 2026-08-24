namespace vtmRevisedCharacterList.AddFormHelper;

public interface IAddFormHelper
{
    public IEnumerable<string> GetAutoComplete();

    public bool Rated => true;
}
