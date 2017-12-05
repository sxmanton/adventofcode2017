﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventDay4
{
    public static class PassPhraseValidator
    {
        public static bool IsValid(string passphrase, IEqualityComparer<string> wordEqualityComparer)
        {
            var words = passphrase.Split(' ');
            if (words.Count() > 1)
            {
                var distinctWordCount = words.Distinct(wordEqualityComparer).Count();
                return words.Count() == distinctWordCount;
            }
            return false;
        }
    }
}
