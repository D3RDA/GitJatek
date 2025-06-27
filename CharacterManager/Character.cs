using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CharacterManager;

public class Character : INotifyPropertyChanged
{

    private int _id;
    private string _name;
    private string _class;
    private int _dmg;
    private int _hp;
    private DateTime _createdAt;

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Class
    {
        get => _class;
        set
        {
            _class = value;
            OnPropertyChanged();
        }
    }

    public int Dmg
    {
        get => _dmg;
        set
        {
            _dmg = value;
            OnPropertyChanged();
        }
    }

    public int Hp
    {
        get => _hp;
        set
        {
            _hp = value;
            OnPropertyChanged();
        }
    }

    public DateTime CreatedAt
    {
        get => _createdAt;
        set
        {
            _createdAt = value;
            OnPropertyChanged();
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
