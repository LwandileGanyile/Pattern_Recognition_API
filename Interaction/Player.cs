using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interaction
{
    public class Player
    {
        private string _playerName;
        private string _playerSurname;
        private int _playerId;


        public Player()
        {

        }

        public Player(string _playerName, string _playerSurname, int _playerId)
        {
            this._playerId = _playerId;
            this._playerName = _playerName;
            this._playerSurname = _playerSurname;


        }

        public Player(string _playerName, string _playerSurname, int _playerId, float _playerMark)
        {
            this._playerId = _playerId;
            this._playerName = _playerName;
            this._playerSurname = _playerSurname;


        }

        public string PlayerName { get; set; }

        public string PlayerSurname { get; set; }

        public int PlayerId { get; set; }


        public void ChooseRhythm()
        {

        }

        public void ChooseKingStep()
        {

        }

        public void ChooseMultiple()
        {

        }

        public void ChooseMusic()
        {

        }

    }
}
