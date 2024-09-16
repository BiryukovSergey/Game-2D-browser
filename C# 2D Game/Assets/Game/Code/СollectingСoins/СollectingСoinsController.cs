namespace Game.Code.СollectingСoins
{
    public class СollectingСoinsController
    {
        private СollectingСoinsView _сollectingСoinsView;

        public СollectingСoinsController(СollectingСoinsView сollectingСoinsView)
        {
            _сollectingСoinsView = сollectingСoinsView;
            _сollectingСoinsView.CoinCollision += MoneyOff;
        }

        private void MoneyOff()
        {
            _сollectingСoinsView.gameObject.SetActive(false);
        }
    }
}