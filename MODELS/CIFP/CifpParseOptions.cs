namespace FAA_DATA_HANDLER.Models.CIFP
{
    /// <summary>
    /// Controls how <c>CifpParserController</c> reads a CIFP file.
    /// </summary>
    public sealed class CifpParseOptions
    {
        /// <summary>
        /// Store the full 132-character source line on every parsed model.
        /// </summary>
        /// <remarks>
        /// Off by default. Turning it on costs roughly one extra string per record - about 52 MB
        /// across a full cycle - and buys the ability to re-slice any column and to trace an odd
        /// value straight back to its source line. Worth enabling while investigating a data issue.
        /// </remarks>
        public bool KeepRawRecord { get; set; }

        /// <summary>
        /// Throw when a line cannot be matched to a known record type, instead of counting it.
        /// </summary>
        /// <remarks>
        /// Off by default, so a future cycle that introduces an unknown record type is reported in
        /// the parse summary rather than aborting the run. Every line in cycle 2607 matches.
        /// </remarks>
        public bool ThrowOnUnknownRecord { get; set; }

        /// <summary>
        /// Collect up to this many sample lines for each problem the parse encounters.
        /// </summary>
        public int MaxSamplesPerIssue { get; set; } = 5;
    }
}
