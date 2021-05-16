using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace client.Shared
{
    public partial class MyComponent
    {
        [Parameter] public string MyValue { get; set; }
        [Parameter] public EventCallback<string> MyValueChanged { get; set; }
        
        /*
         * Der Binding Ausdruck wird bei Laufzeit abgefüllt. Die Expression beinhaltet den Code, welcher auf die Quelle
         * der der Datenbindung zeigt.
         *
         * Damit können erweiterte Szenarios wie z.B. Controls, welche Validierung unterstützen usw. implementiert werden.
         *
         * mehr lesen: https://stackoverflow.com/a/66262767/4099159
         * 
        [Parameter]
        public Expression<Func<string>> MyValueExpression { get; set; }
         */
        
        private void BananenbrotClicked()
        {
            MyValue = $"{MyValue} mit Bananenbrot";
            MyValueChanged.InvokeAsync(MyValue);
        }
    }
}