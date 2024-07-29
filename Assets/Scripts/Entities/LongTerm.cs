using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Entities
{
    public class LongTerm : MonoBehaviour
    {
        [FormerlySerializedAs("cellsField")] [SerializeField] private RectTransform trmcel;
        [FormerlySerializedAs("cellPrefab")] [SerializeField] private RectTransform termpref;
        [FormerlySerializedAs("diamondsPrefabs")] [SerializeField] private Jira[] jirpref;
        [FormerlySerializedAs("destroyDuration")] [SerializeField] private float detrestrp3;
        [FormerlySerializedAs("moveDuration")] [SerializeField] private float mvDurt2;
        [FormerlySerializedAs("collectingDiamondsCells")] [SerializeField] private GameObject[] vflckw;
        [FormerlySerializedAs("collectingDiamondsScore")] [SerializeField] private Text[] cldscr3;
        [FormerlySerializedAs("diamondCost")] [SerializeField] private int dmvdcts = 10;
        [FormerlySerializedAs("winCount")] [SerializeField] private int wnctnt2 = 50;
        [FormerlySerializedAs("time")] [SerializeField] private int tm23 = 120;
        [FormerlySerializedAs("rows")] [SerializeField] private int rosw2 = 8;
        [FormerlySerializedAs("cols")] [SerializeField] private int ecl = 6;
        [FormerlySerializedAs("verticalOffset")] [SerializeField] private float vtrofset2 = 30;
        [FormerlySerializedAs("horizontalOffset")] [SerializeField] private float gohorsdft = 30;
        [FormerlySerializedAs("verticalMargin")] [SerializeField] private float vtbfmq = 60;
        [FormerlySerializedAs("horizontalMargin")] [SerializeField] private float efsdvr = 60;
        
        private int _scrt = 0;
        private RectTransform[][] _ceslew;
        private Jira[][] _dawefr;
        private VolMangr _sdrewvMsa;
        private int _Wdsftj;
        private Coroutine _spawqeksSDerwqA;
        private Jira _prefvtSAdsdfw;
        private bool _asdwWAsd = false;
        private bool _isWqwdrW = false;
        private Dictionary<int, (int, int)> _colwqWqwe = new Dictionary<int, (int, int)>();
        private (float, Action) _lasqWqwedAS;
        private int _pawdcAwqe = 0;
        private bool _isWqwf = false;
        private Jira[] _selfvAWwef;

        public event Action<int> OnScoreChange;
        public event Action<int> OnTimeChange;
        public event Action OnWin;
        public event Action OnLose;

        public int Scrt => _scrt;

        public void Bootstrap(VolMangr sdrewvMsa, int Wdsftj, int qwekd, int ase=123, string wrf="asd")
        {
            _sdrewvMsa = sdrewvMsa;
            _Wdsftj = Wdsftj;

            // time += 30 * (level / 3);
            OnTimeChange.Invoke(tm23);
            // winCount += 5 * (level / 3);
        }

        private void Start()
        {
            Random.InitState((int) Stopwatch.GetTimestamp());
            OnScoreChange?.Invoke(_scrt);
            foreach (var t in cldscr3)
            {
                t.text = $"x{wnctnt2}";
            }

            _selfvAWwef = new Jira[Math.Min(rosw2, ecl)];

            jirpref.OrderBy(t => Random.value)
                .Take(_selfvAWwef.Length)
                .ToArray()
                .CopyTo(_selfvAWwef, 0);
            
            Casqwef(500);

            int i = 0;
            foreach (var jira in _selfvAWwef.OrderBy(t => Random.value)
                         .Take(vflckw.Length))
            {
                _colwqWqwe[jira.Jirai] = (i, 0);

                Instantiate(jira, vflckw[i].transform);
                
                i += 1;
            }
            
            VdskwerSqwe(123);
        }

        public void AwqefS()
        {
            StartCoroutine(TickTime());

            if (_lasqWqwedAS == default)
                return;

            foreach (var arr in _dawefr)
            {
                foreach (var diamond in arr)
                {
                    diamond?.Svrwq();
                }
            }

            StartCoroutine(CallDelayed(_lasqWqwedAS.Item1, _lasqWqwedAS.Item2));
        }

        private void Casqwef(int awq123)
        {
            _ceslew = new RectTransform[rosw2][];
            _dawefr = new Jira[rosw2][];
            
            for (int i = 0; i < rosw2; ++i)
            {
                _ceslew[i] = new RectTransform[ecl];
                _dawefr[i] = new Jira[ecl];
                
                for (int j = 0; j < ecl; ++j)
                {
                    var rtfe = Instantiate(termpref, trmcel);
                    rtfe.anchoredPosition = new Vector3(
                        gohorsdft + efsdvr * j,
                        -vtrofset2 - vtbfmq * i,
                        0
                    );

                    _ceslew[i][j] = rtfe;
                }
            }
        }
        
        private void VdskwerSqwe(int tq2)
        {
            tq2 += 2;
            for (int i = 0; i < rosw2; ++i)
            {
                for (int j = 0; j < ecl; ++j)
                {
                    if (_dawefr[i][j] != null)
                        continue;
                    
                    var jira = Instantiate(
                        _selfvAWwef[Random.Range(0, _selfvAWwef.Length)], 
                        _ceslew[i][j].transform
                    );
                    _dawefr[i][j] = jira;

                    jira.OnClick += MdqweLSaq;
                    jira.OnDragged += DdewOsadqD;
                }
            }
            
            VdaswEwqefFa(false);
        }

        private void SelJira(Jira jira)
        {
            if (_prefvtSAdsdfw is null)
            {
                _prefvtSAdsdfw = jira;
                return;
            }
            
            _asdwWAsd = true;

            (int, int) coors1 = GdsWqdE(_prefvtSAdsdfw);
            (int, int) coors2 = GdsWqdE(jira);
            
            _prefvtSAdsdfw = null;
            
            _sdrewvMsa.OnDiamondClick();
            
            SsawRmsa(coors1, coors2);
            var match1 = ChdsWM(coors1.Item1, coors1.Item2);
            var match2 = ChdsWM(coors2.Item1, coors2.Item2);
            
            if (FdinwqWfa().Count == 0)
            {
                StartCoroutine(
                    CallDelayed(mvDurt2, () => SsawRmsa(coors1, coors2))
                );
                StartCoroutine(CallDelayed(mvDurt2 * 2, () => _asdwWAsd = false));
                
                return;
            }
            
            StartCoroutine(CallDelayed(mvDurt2, () => VdaswEwqefFa(true)));
        }

        private void SsawRmsa((int, int) coors1, (int, int) coors2)
        {
            var jira1 = _dawefr[coors1.Item1][coors1.Item2];
            var jira2 = _dawefr[coors2.Item1][coors2.Item2];
            
            (_dawefr[coors1.Item1][coors1.Item2], _dawefr[coors2.Item1][coors2.Item2]) = 
                (jira2, jira1);

            if (jira1 != null)
            {
                jira1.transform.SetParent(_ceslew[coors2.Item1][coors2.Item2]);
                jira1.MoveToCenter(mvDurt2);
            }

            if (jira2 != null)
            {
                jira2.transform.SetParent(_ceslew[coors1.Item1][coors1.Item2]);
                jira2.MoveToCenter(mvDurt2);
            }
        }

        private void VdaswEwqefFa(bool tq)
        {
            var iie = FdinwqWfa();

            if (iie.Count > 0)
            {
                DsdfMatg(iie);
            }
            else
            {
                _isWqwdrW = true;
                _asdwWAsd = false;
            }
        }

        private HashSet<(int, int)> FdinwqWfa()
        {
            HashSet<(int, int)> matches = new HashSet<(int, int)>();

            for (int i = 0; i < rosw2; ++i)
            {
                for (int j = 0; j < ecl; ++j)
                {
                    (bool horizontal, bool vertical) = ChdsWM(i, j);

                    if (horizontal)
                    {
                        matches.Add((i, j - 1));
                        matches.Add((i, j));
                        matches.Add((i, j + 1));
                    }
                    
                    if (vertical)
                    {
                        matches.Add((i - 1, j));
                        matches.Add((i, j));
                        matches.Add((i + 1, j));
                    }
                }
            }

            return matches;
        }

        private void DsdfMatg(HashSet<(int, int)> matches)
        {
            foreach (var match in matches)
            {
                var diamond = _dawefr[match.Item1][match.Item2];
                _dawefr[match.Item1][match.Item2] = null;
                
                diamond.OnClick -= MdqweLSaq;
                diamond.OnDragged -= DdewOsadqD;

                if (_isWqwdrW)
                {
                    UpdateScore(diamond);
                    
                    diamond.Destroy(detrestrp3);
                }
                else
                {
                    Destroy(diamond.gameObject);
                }
            }

            if (_isWqwdrW)
            {
                if (matches.Count > 0)
                    _sdrewvMsa.OnCoinCollect();
                
                StartCoroutine(CallDelayed(detrestrp3, DsqwLevMdaw));
            }
            else
            {
                VdskwerSqwe(123);
            }
        }

        private (bool, bool) ChdsWM(int i, int j) =>
        (
            (j > 0 && j < ecl - 1 &&
             _dawefr[i][j - 1] != null && _dawefr[i][j] != null && _dawefr[i][j + 1] != null &&
             _dawefr[i][j - 1]?.Jirai == _dawefr[i][j]?.Jirai &&
             _dawefr[i][j]?.Jirai == _dawefr[i][j + 1]?.Jirai),
            (i > 0 && i < rosw2 - 1 &&
             _dawefr[i - 1][j] != null && _dawefr[i][j] != null && _dawefr[i + 1][j] != null &&
             _dawefr[i - 1][j]?.Jirai == _dawefr[i][j]?.Jirai &&
             _dawefr[i][j]?.Jirai == _dawefr[i + 1][j]?.Jirai)
        );

        private void UpdateScore(Jira jira)
        {
            _scrt += dmvdcts;
            if (_colwqWqwe.ContainsKey(jira.Jirai))
            {
                (int index, int count) = _colwqWqwe[jira.Jirai];
                count = Math.Min(count + 1, wnctnt2);

                cldscr3[index].text = $"x{wnctnt2 - count}";

                _colwqWqwe[jira.Jirai] = (index, count);
            }
            
            OnScoreChange?.Invoke(_scrt);

            if (_colwqWqwe.Values.All(t => t.Item2 == wnctnt2) && !_isWqwf)
            {
                _asdwWAsd = _isWqwf = true;
                _sdrewvMsa.OnWin();
                OnWin?.Invoke();
            }
        }

        private void DsqwLevMdaw()
        {
            for (int i = rosw2 - 1; i >= 0; --i)
            {
                for (int j = ecl - 1; j >= 0; --j)
                {
                    if (_dawefr[i][j] is null)
                    {
                        for (int k = i - 1; k >= 0; --k)
                        {
                            if (_dawefr[k][j] is null)
                                continue;

                            SsawRmsa((i, j), (k, j));
                            break;
                        }
                    }
                }
            }

            StartCoroutine(CallDelayed(mvDurt2, () => VdskwerSqwe(123)));
        }

        private void MdqweLSaq(Jira jira)
        {
            if (_asdwWAsd)
                return;
            
            SelJira(jira);
        }

        private void DdewOsadqD(Jira jira, Vector2 drew1)
        {
            if (_asdwWAsd)
                return;

            (int i, int j) = GdsWqdE(jira);
            
            if (Mathf.Abs(drew1.x) - Mathf.Abs(drew1.y) > 0)
            {
                j += Math.Sign(drew1.x);
            }
            else
            {
                i -= Math.Sign(drew1.y);
            }

            if (i < 0 || j < 0 || i >= rosw2 || j >= ecl)
                return;
            
            SelJira(jira);
            SelJira(_dawefr[i][j]);
        }

        private (int, int) GdsWqdE(Jira jira)
        {
            for (int i = 0; i < rosw2; ++i)
            {
                for (int j = 0; j < ecl; ++j)
                {
                    if (_dawefr[i][j] == jira)
                        return (i, j);
                }
            }

            return (-1, -1);
        }

        private IEnumerator CallDelayed(float delay, Action callback)
        {
            _lasqWqwedAS = (delay, callback);
            
            yield return new WaitForSeconds(delay);

            _lasqWqwedAS = default;
            callback.Invoke();
        }

        private IEnumerator TickTime()
        {
            while (true)
            {
                _pawdcAwqe += 1;
                
                OnTimeChange.Invoke(tm23 - _pawdcAwqe);

                if (_pawdcAwqe >= tm23)
                {
                    _asdwWAsd = true;
                    OnLose.Invoke();
                    break;
                }

                yield return new WaitForSeconds(1);
            }
        }
    }
}