using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerTable : Furniture
{

    [SerializeField] private BookToPaperSO[] bookList;
    [SerializeField] private Printer linkedPrinter;
    public override void Interact(Character character) {
        if (!hasClassroomObject()) {
            if (character.hasClassroomObject()) {
                if (hasBook(character.GetClassroomObject().getPickUpObject())) {
                    character.GetClassroomObject().setParentObject(this);
                }
            }
        } else {
            if (!character.hasClassroomObject()) {
                GetClassroomObject().setParentObject(character);
            }
        }
    }

    public override void Use(Character character) {
        if (linkedPrinter.hasClassroomObject() || linkedPrinter.isPrinting()) {
            Debug.Log("Printer is occupied!");
            return;
        }
        if (hasClassroomObject() && hasBook(GetClassroomObject().getPickUpObject())) {
            QuizManager.Instance.askQuestions(this);
        }
    }

    public void beginPrinting() {
        BookToPaperSO bookToPaperSO = getbookToPaperSO(GetClassroomObject().getPickUpObject());
        GetClassroomObject().removeObject();
        linkedPrinter.beginPrinting(bookToPaperSO.output, bookToPaperSO.printingTime);
    }

    private bool hasBook(pickUpObject itemOnTable) {
        BookToPaperSO bookToPaper = getbookToPaperSO(itemOnTable);
        return bookToPaper != null;
    }

    private pickUpObject bookToPaper(pickUpObject itemOnTable) {
        BookToPaperSO bookToPaper = getbookToPaperSO(itemOnTable);
        if (bookToPaper != null) {
            return bookToPaper.output;
        }
        return null;
    }

    private BookToPaperSO getbookToPaperSO(pickUpObject itemOnTable) {
        foreach (BookToPaperSO bookTransform in bookList) {
            if (bookTransform.input == itemOnTable) {
                return bookTransform;
            }
        }
        return null;
    }
}
