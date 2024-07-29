namespace UI.Screens
{
    public abstract class PayloadedScreen<TPayload> : BasCreen
    {
        protected TPayload _payload;

        public virtual void SetPayload(TPayload payload)
        {
            _payload = payload;
        }
    }
}