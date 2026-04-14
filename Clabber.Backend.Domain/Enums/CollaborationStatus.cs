namespace Clabber.Backend.Domain.Enums
{
    public enum CollaborationStatus
    {
        // Buyer has sent a proposal to the Creator (based on Predictive Analysis)
        Requested = 1,

        // Creator has seen the request and turned it down
        Declined = 2,

        // Creator has agreed to the terms; money should move to Escrow now
        Accepted = 3,

        // The creator has filmed the video and uploaded the link for review
        SubmittedForReview = 4,

        // Buyer is unhappy with the video and requested a change/edit
        RevisionRequested = 5,

        // Buyer approved the content; video is now scheduled or live
        Approved = 6,

        // The video is live, the sound is tagged, and payment is released
        Completed = 7,

        // Something went wrong (e.g., creator deleted the video early)
        Disputed = 8,

        // The deal was cancelled by either party before the video was made
        Cancelled = 9
    }
}