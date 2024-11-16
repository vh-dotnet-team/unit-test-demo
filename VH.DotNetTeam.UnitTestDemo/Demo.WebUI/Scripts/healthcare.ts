// Function to open the journey modal
function openJourneyModal(): void {
    // Fetch the journey data from the backend
    fetch('/Healthcare/Journey')
        .then((response: Response) => response.text())
        .then((html: string) => {
            // Inject the received HTML into the journey-container element
            const journeyContainer = document.getElementById("journey-container") as HTMLElement;
            journeyContainer.innerHTML = html;

            // Get modal and close button elements
            const modal = document.getElementById("journeyModal") as HTMLElement;
            const closeBtn = document.querySelector(".close") as HTMLElement;

            // Display the modal
            modal.style.display = "block";

            // Add event listener to close the modal when the close button is clicked
            closeBtn.onclick = function (): void {
                modal.style.display = "none";
            };

            // Close the modal when clicking outside of the modal content
            window.onclick = function (event: MouseEvent): void {
                if (event.target === modal) {
                    modal.style.display = "none";
                }
            };
        })
        .catch((error: Error) => {
            console.error('Error fetching journey data:', error);
        });
}

// Attach event listener to the "View Full Journey" button
const journeyBtn = document.getElementById("journey-btn") as HTMLButtonElement;
if (journeyBtn) {
    journeyBtn.addEventListener("click", openJourneyModal);
}
