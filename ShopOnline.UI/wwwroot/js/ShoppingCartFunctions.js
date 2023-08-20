function MakeUpdateQtyButtonVisible(id, visible)
{
	const updatedQtyButton = document.querySelector("button[data-itemId='" + id + "']");
	if (visible) {
		updatedQtyButton.style.display = "inline-block";
	}
	else {
		updatedQtyButton.style.display = "none";
	}
}
