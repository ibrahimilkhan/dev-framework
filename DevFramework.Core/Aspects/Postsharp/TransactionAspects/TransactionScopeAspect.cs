using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DevFramework.Core.Aspects.Postsharp.TransactionAspects
{
    [Serializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        private TransactionScopeOption _transactionScopeOption;

        public TransactionScopeAspect()
        {

        }

        public TransactionScopeAspect(TransactionScopeOption transactionScopeOption)
        {
            _transactionScopeOption = transactionScopeOption;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            //Metoda girdiği anda çalışmaya başlayacak

            args.MethodExecutionTag = new TransactionScope(_transactionScopeOption);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            // Try içinde başarılı olursa bitirecek.

            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            // Catch'e düşerse dispose edecek. Başarılı olursa buraya hiç girmiyor.

            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
