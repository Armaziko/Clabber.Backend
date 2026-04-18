namespace Clabber.Backend.Domain.Enums
{
    public enum EscrowTransactionType
    {
        /// <summary>
        /// Sponsor deposits funds into Clabber's secure escrow.
        /// </summary>
        Deposit = 1,

        /// <summary>
        /// Funds are released to the Creator after work is approved.
        /// </summary>
        Release = 2,

        /// <summary>
        /// Funds are returned to the Sponsor due to a cancellation or dispute.
        /// </summary>
        Refund = 3,

        /// <summary>
        /// Payment of the platform service fee to Clabber.
        /// </summary>
        PlatformFee = 4,

        /// <summary>
        /// Additional performance-based payments released from escrow.
        /// </summary>
        BonusPayment = 5
    }
}
