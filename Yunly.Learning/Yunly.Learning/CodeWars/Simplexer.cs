﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;

namespace Yunly.Learning.CodeWars
{
    /*
     The Challenge
You'll need to implement a simple lexer type. It should take in an input string through the constructor (or the parameter, for Javascript), and break it up into typed-tokens (in python, C# and Java, you'll have to manage null/None input too, resulting in the same behavior than an empty string). You'll need to implement the necessary methods (aaccording to your language) to make the Simplexer object behave like an iterator, Meaning that it returns a token (assuming one is available) object each time it a next (Current field in C#) method would be called. If no tokens are available, an exception should be thrown (idealy: StopIteration in python, InvalidOperationException in C# and NoSuchElementException in Java).

Tokens are represented by Token objects, which define two properties as strings: text, and type. Constructor is Token(text, type).

C# Notes:

Iterator<T> is an extension of IEnumerator<T> with default implementations for Reset(), Dispose() and IEnumerator.Current as these are not need to pass the challenge. You only need to override MoveNext() and Current { get; }.

Token Types
There are 7 tokens types that your lexer will need to produce: identifier, string, integer, boolean, keyword, operator, and whitespace. To create the token, you'd need to pass in the token value (the text) and the token type as strings, so for example, a simple integer token could be created with new Token("1", "integer") (Note: no default values or default constructor are provided, so use new Token("","") if you want a default Token object).

Token Grammar
Here's a table of the grammars for the various token types:

integer : Any sequence of one or more digits.

boolean : true or false.

string : Any sequence of characters surrounded by "double quotes".

operator : The characters +, -, *, /, %, (, ), and =.

keyword : The following are keywords: if, else, for, while, return, func, and break.

whitespace : Matches standard whitespace characters (space, newline, tab, etc.)
Consecutive whitespace characters should be matched together.

identifier : Any sequence of alphanumber characters, as well as underscore and dollar sign,
and which doesn't start with a digit. Make sure that keywords aren't matched as identifiers!
     */



    public class Simplexer : IEnumerator<Token>
    {
        IEnumerator<Token> iter;

        public Token Current => iter.Current;

        object IEnumerator.Current => throw new NotImplementedException();

        public Simplexer(string buffer)
        {
            string[] types = { "integer", "boolean", "string", "operator", "keyword", "whitespace", "identifier" };

            var matches = new Regex("(\\d+)|(true|false)|(\".+\")|([-+*\\/%\\(\\)=])|(if|else|for|while|return|func|break)|(\\s+)|([\\w$]+)")
                .Matches(buffer == null ? "" : buffer);
            
            iter = matches.Cast<Match>()
                .Select(x => {
                    int index = x.Groups.Cast<Group>().ToList().FindLastIndex(y => y.Length > 0);
                    return new Token(x.Groups[index].Value, types[index - 1]);
                })
                .GetEnumerator();
        }

        public bool MoveNext()
        {
            return iter.MoveNext();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

   

       
    }

    public class Token
    {
        public string tokenValue;
        public string TokenType;

        public Token(string value, string type)
        {
            this.tokenValue = value;
            this.TokenType = type;
        }

        public override string ToString()
        {
            return $"{tokenValue}:({TokenType})";
        }
    }

}