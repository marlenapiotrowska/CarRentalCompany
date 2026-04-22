namespace CarRentalCompany.Frontend.Presentation.Views.Generic
{
    internal abstract class View : IView
    {
        public async Task RenderAsync()
        {
            Console.Clear();

            await RenderViewAsync();

            Console.Clear();
        }

        protected abstract Task RenderViewAsync();
    }
}
