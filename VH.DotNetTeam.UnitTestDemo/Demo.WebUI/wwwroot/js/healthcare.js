// Function to open the journey modal
function openJourneyModal() {
    // Fetch the journey data from the backend
    fetch('/Healthcare/Journey')
        .then(function (response) { return response.text(); })
        .then(function (html) {
        // Inject the received HTML into the journey-container element
        var journeyContainer = document.getElementById("journey-container");
        journeyContainer.innerHTML = html;
        // Get modal and close button elements
        var modal = document.getElementById("journeyModal");
        var closeBtn = document.querySelector(".close");
        // Display the modal
        modal.style.display = "block";
        // Add event listener to close the modal when the close button is clicked
        closeBtn.onclick = function () {
            modal.style.display = "none";
        };
        // Close the modal when clicking outside of the modal content
        window.onclick = function (event) {
            if (event.target === modal) {
                modal.style.display = "none";
            }
        };
    })
        .catch(function (error) {
        console.error('Error fetching journey data:', error);
    });
}
// Attach event listener to the "View Full Journey" button
var journeyBtn = document.getElementById("journey-btn");
if (journeyBtn) {
    journeyBtn.addEventListener("click", openJourneyModal);
}
//# sourceMappingURL=healthcare.js.map