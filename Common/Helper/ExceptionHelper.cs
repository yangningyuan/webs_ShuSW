using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Common.Helper
{
    public class ExceptionHelper
    {

        public static bool TryCatch(Expression<Action> action, Action<Exception> failureAction, Action successAction)
        {
            try
            {
                action.Compile().Invoke();
                successAction.Invoke();
                return true;
            }
            catch (Exception ex)
            {
#if DEBUG
                Trace.WriteLine(ex.Message);
                Trace.WriteLine(ex.StackTrace);
#endif
                failureAction.Invoke(ex);
                return false;
            }
        }
    }
}
