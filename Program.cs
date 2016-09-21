﻿using System;
using Antlr4.Runtime;
using advpl_parser.grammar;
using advpl_parser.util;

class Program
{
    private static void Main(string[] args)
    {
        (new Program()).Run(args);
    }
    public void Run(string[] args)
    {
        try
        {
            RunParser(args[0]);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex);
        }

    }
    private void RunParser(string source)
    {
        NoCaseANTLRFileStream inputStream = new NoCaseANTLRFileStream(source);
        AdvplLexer lexer = new AdvplLexer(inputStream);
        CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
        AdvplParser advplParser = new AdvplParser(commonTokenStream);
        advplParser.RemoveErrorListeners();
        AdvplErrorListener errorListener = new AdvplErrorListener();
        advplParser.AddErrorListener(errorListener);
        ParserRuleContext tree = advplParser.program();

        if (advplParser.NumberOfSyntaxErrors == 0)
        {
            System.Console.WriteLine("OK");
        }
        else
        {
            System.Console.WriteLine("AdvplParser Error.");
            foreach (AdvplErroInfo info in errorListener.Errors)
            {
                System.Console.WriteLine(info.ToString());
            }
            
        }
            
        }
    }