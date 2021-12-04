namespace ScoreKeeper
{
    public class ScoreKeeper
    {
        private TeamScore scoreA = new TeamScore();
        private TeamScore scoreB = new TeamScore();

        public string GetScore() => $"{scoreA}:{scoreB}";

        public void ScoreTeamA1() => scoreA.AddPoints(1);
        public void ScoreTeamA2() => scoreA.AddPoints(2);
        public void ScoreTeamA3() => scoreA.AddPoints(3);

        public void ScoreTeamB1() => scoreB.AddPoints(1);
        public void ScoreTeamB2() => scoreB.AddPoints(2);
        public void ScoreTeamB3() => scoreB.AddPoints(3);

        private class TeamScore
        {
            private int score = 0;

            public void AddPoints(int points) => score += points;
            public override string ToString() => $"{score:000}";
        }
    }
}
