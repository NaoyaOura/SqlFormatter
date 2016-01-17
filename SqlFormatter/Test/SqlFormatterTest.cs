using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using SqlFormatter.Config;
using SqlFormatter.SQL.Ast;
using SqlFormatter.SQL.Ast.Parser;
using SqlFormatter.SQL.Ast.Transformer;
using SqlFormatter.SQL.Ast.Visitor;
using SqlFormatter.Tools;

namespace SqlFormatter.Test
{

    [TestFixture]
    class SqlFormatterTest
    {

        private readonly string _resourcePath;
        private readonly string _defaultConfigPath;

        public SqlFormatterTest()
        {
            _resourcePath = AppDomain.CurrentDomain.BaseDirectory + @"\..\..\Test\Resource";
            _defaultConfigPath = _resourcePath + @"\config\default.xml";
        }

        /// <summary>
        /// 正常系のテスト
        /// </summary>
        [Test]
        public void SimpleSelectTest()
        {
            string input = ReadFile(_resourcePath + @"\SimpleSelectTestInput.sql");
            string output = ExecuteFormatter(input);
            string expected = ReadFile(_resourcePath + @"\SimpleSelectTestOutput.sql");
            Assert.AreEqual(expected, output);
        }

        /// <summary>
        /// コメント削除機能のテスト
        /// </summary>
        [Test]
        public void DeleteCommentTest()
        {
            ConfigEntity entity = Serializer.Load<ConfigEntity>(_defaultConfigPath);
            entity.IsDeleteComment = true;
            string input = ReadFile(_resourcePath + @"\DeleteCommentTestInput.sql");
            string output = SqlFormatter(input,entity);
            string expected = ReadFile(_resourcePath + @"\DeleteCommentTestOutput.sql");
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TopReservedWordIndentTest()
        {
            ConfigEntity entity = Serializer.Load<ConfigEntity>(_defaultConfigPath);
            entity.TopReservedWordAfterIndent = TopReservedWordIndentType.Invalid;
            string input = ReadFile(_resourcePath + @"\TopReservedWordIndentTestInput.sql");
            string output = SqlFormatter(input, entity);
            string expected = ReadFile(_resourcePath + @"\TopReservedWordIndentTestOutput.sql");
            Assert.AreEqual(expected, output);
            
        }

        [TestCase("WhereEqualAlignTest")]
        [TestCase("NestSqlTest")]
        [TestCase("CaseFormulaDefaultTest")]
        [TestCase("HintCommentIndentTest")]
        [TestCase("ReservedWordAsCompletionTest")]
        public void SimpleTestCase(string testName)
        {
            string input = ReadFile(_resourcePath + @"\" + testName + "Input.sql");
            string output = ExecuteFormatter(input);
            string expected = ReadFile(_resourcePath + @"\" + testName + "Output.sql");
            Assert.AreEqual(expected, output);
        }

        /// <summary>
        /// sqlformatterを実行して結果の文字列を返す
        /// </summary>
        /// <param name="inputSql"></param>
        /// <returns></returns>
        public string ExecuteFormatter(string inputSql)
        {
            ConfigEntity entity = Serializer.Load<ConfigEntity>(_defaultConfigPath);
            return SqlFormatter(inputSql, entity);
        }

        public string SqlFormatter(string inputSql, ConfigEntity entity)
        {
            SqlAstParser sqlAstParser = new SqlAstParser();
            SqlCompilationUnit unit = sqlAstParser.Parse(inputSql);
            SqlAstVisitor visitor = new SqlFormatVisitor(entity);
            IList<ITransformer> transformers = new List<ITransformer>();
            transformers.Add(new CaseTransform(entity));
            transformers.Add(new CommentTransform(entity.IsDeleteComment));
            if (entity.IsReservedWordAsComplement)
            {
                transformers.Add(new AsWordCompletionTransform(entity));
            }
            unit.Accept(visitor, transformers);
            return visitor.ResultSql;
        }

        /// <summary>
        /// ファイルを読み込み、結果を文字列として返す
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadFile(string path)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader r = new StreamReader(path))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            return sb.ToString();
        }

    }
}
