namespace CarRentalCompany.Frontend.Presentation.Views.Generic
{
    internal abstract class View : IView
    {
        protected abstract Task RenderViewAsync();

        public async Task RenderAsync()
        {
            Console.Clear();

            await RenderViewAsync();

            Console.Clear();
        }
    }
}
