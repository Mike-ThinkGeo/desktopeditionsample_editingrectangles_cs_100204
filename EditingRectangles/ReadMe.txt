This sample shows how to extend the EditInteractiveOverlay rectangles as shapes rather than polygon shapes by setting special column values.  For features (Well Known Text and Binary), the concept of a rectangle is not supported and typically rectangles are handled as polygons.  This feature allows users to modify the rectangle but requires that the modification keep a rectangular form.  The rectangle doesn't need to be straight as long as all of the corner angles are at 90 degrees relative to each other.

To activate the feature, you need to assign the value of the column called "Edit" to "rectangle".  The resize function will keep the ratio of width and height of the rectangle, otherwise it will use the original method.

For more information you can see the discussion forum post below:
http://gis.thinkgeo.com/Support/DiscussionForums/tabid/143/aff/21/aft/5822/afv/topic/Default.aspx