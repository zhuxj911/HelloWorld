using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ZXY;

public class NotificationObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
    {
        var memberExpression = (MemberExpression)propertyExpression.Body;
        string propertyName = memberExpression.Member.Name; //利用反射获取属性对名称 Lambda表达式 () => Name
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}