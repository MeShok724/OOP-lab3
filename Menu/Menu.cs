using System;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace WindowsFormsApp1.Menu
{
    public class Menu
    {
        public int _curItemPos;
        public int _p;

        public GameField _gameField;

        public MenuItem[] _menuItems = new MenuItem[0];
        public MenuItem[] _editItems = new MenuItem[3];
        public static string[] _objTypes = new string[] { "rectangle", "ellipse", "square", "circle", "triangle" };


        private static int _itemToEditIndex;
        public int _subMenuIndex;


        bool _isClicked = true;

        public Menu(GameField gameField)
        {
            this._gameField = gameField;

            createEditFields(_gameField._windowWidth, _gameField._windowHeight);

            _subMenuIndex = 0;
            _itemToEditIndex = 0;
            _curItemPos = 0;
        }

        public void createEditFields(int width, int height)
        {
            createEditField(width, height, 1, 0, "Add item...");
            AddEditSubmenu("Add menu", width, height, 1, 1);
            AddEditSubmenu("Add submenu", width, height, 1, 2);
            createEditField(width, height, 1, 3, "Edit item");
            createEditField(width, height, 1, 4, "Delete item");
        }
        private void createEditField(int width, int height, int shiftX, int shiftY, string text)
        {
            Rectangle obj = new Rectangle(0, 0, 10, 10, 150, 150, 150, 150, 150, 255, 255, 25, 5);

            changePos(obj, width - 190 * shiftX, 20 + 70*shiftY);
            resize(obj, 170, 50);

            obj._cR = 255;
            obj._cG = 255;
            obj._cB = 255;
            obj._bR = 100;
            obj._bG = 170;
            obj._bB = 100;

            obj._borderWidth = 2;

            _editItems[_curItemPos] = new MenuItem(100, 100, 14, text, "Arial", 0, 0, 0, obj, _p, _gameField);

            _p++;
            _curItemPos++;
        }

        public void AddEditSubmenu(string text, int width, int height, int shiftX, int shiftY)
        {
            _editItems[0].subMenuItems = createSubmenu(_editItems[0].subMenuItems);
            _editItems[0].subMenuItems[_editItems[0]._submenuCount] =
                AddRandomSubitem(_objTypes[0], width - 190 * shiftX, 20 + shiftY * 70, 14, text, 220, 220, 220);
            _editItems[0].subMenuItems[_editItems[0]._submenuCount]._index = _subMenuIndex;
            _editItems[0]._submenuCount++;
            _editItems[0].subMenuItems[_subMenuIndex]._frameObj._cR = 255;
            _editItems[0].subMenuItems[_subMenuIndex]._frameObj._cG = 255;
            _editItems[0].subMenuItems[_subMenuIndex]._frameObj._cB = 255;
            _editItems[0].subMenuItems[_subMenuIndex]._tR = 0;
            _editItems[0].subMenuItems[_subMenuIndex]._tG = 0;
            _editItems[0].subMenuItems[_subMenuIndex]._tB = 0;
            _editItems[0].subMenuItems[_subMenuIndex]._frameObj._bR = 100;
            _editItems[0].subMenuItems[_subMenuIndex]._frameObj._bG = 170;
            _editItems[0].subMenuItems[_subMenuIndex]._frameObj._bB = 100;

            _editItems[0].subMenuItems[_subMenuIndex]._frameObj._borderWidth = 2;

            _subMenuIndex++;
        }

        public MenuItem AddRandomSubitem(string objType, int x, int y, int fontSize, string text, int tR, int tG, int tB)
        {
            if (objType == "rectangle")
            {
                Rectangle obj = _gameField.generateRandomRectangle();
                changePos(obj, x, y);
                resize(obj, 170, 50);

                return new MenuItem(x, y, fontSize, text, "Arial", tR, tG, tB, obj, _p, _gameField);
            }

            return null;
        }

        private MenuItem[] createSubmenu(MenuItem[] submenu)
        {
            MenuItem[] newArray = new MenuItem[submenu.Length + 1];

            Array.Copy(submenu, newArray, submenu.Length);

            return newArray;
        }

        public void resize(DisplayObject obj, int width, int height)
        {
            obj._clientX2 = obj._clientX1 + width;
            obj._clientY2 = obj._clientY1 + height;
        }

        public void changePos(DisplayObject obj, int x, int y)
        {
            obj._clientX1 = x;
            obj._clientY1 = y;
            obj._clientX2 = x + (obj._clientX2 - obj._clientX1);
            obj._clientY2 = y + (obj._clientY2 - obj._clientY1);
        }

        public void changeFrameColor(DisplayObject obj, int r, int g, int b)
        {
            obj._cR = r;
            obj._cG = g;
            obj._cB = b;
        }

        public void onClick(int x, int y, MenuItem[] items)
        {

            bool isFind = false;
            foreach (var obj in items)
            {
                if ((x >= obj._frameObj._clientX1 && x <= obj._frameObj._clientX2) && (y >= obj._frameObj._clientY1 && y <= obj._frameObj._clientY2))
                {
                    if (obj._isVisible)
                    {
                        _itemToEditIndex = obj._index;
                    }
                    int pos = 0;

                    for (int i = 0; i < _menuItems.Length; i++)
                    {
                        if (_menuItems[i]._index == _itemToEditIndex)
                        {
                            pos = i;
                            break;
                        }
                    }

                    _isClicked = !_isClicked;

                    if (_isClicked)
                    {
                        int len = pos + _menuItems[pos]._submenuCount + 1;
                        for (int i = pos + 1; i < len; i++)
                        {
                            if (_menuItems[i]._isParent)
                                len += _menuItems[i]._submenuCount;
                            _menuItems[i]._isVisible = false;
                        }
                    }
                    else
                    {
                        int len = pos + _menuItems[pos]._submenuCount + 1;

                        int i = pos + 1;

                        while (i < len)
                        {
                            _menuItems[i]._isVisible = true;

                            if (_menuItems[i]._isParent)
                            {
                                len += _menuItems[i]._submenuCount;
                                i += _menuItems[i]._submenuCount + 1;
                                continue;
                            }
                            i++;
                        }


                    }

                    isFind = true;

                }
            }

            if (!isFind)
            {
                for (int i = 0; i < _menuItems.Length; i++)
                {
                    if (!_menuItems[i]._isAbsolute)
                    {
                        _menuItems[i]._isVisible = false;
                    }
                }
            }

        }

        public void onEditClick(int x, int y, MenuItem[] editItems)
        {
            foreach (var obj in editItems)
            {
                if ((x >= obj._frameObj._clientX1 && x <= obj._frameObj._clientX2) && (y >= obj._frameObj._clientY1 && y <= obj._frameObj._clientY2) && obj._index == 0 && Program._isEditVisible)
                {
                    foreach (var submenu in obj.subMenuItems)
                    {
                        submenu._isVisible = !submenu._isVisible;
                    }
                }

                if ((x >= obj._frameObj._clientX1 && x <= obj._frameObj._clientX2) && (y >= obj._frameObj._clientY1 && y <= obj._frameObj._clientY2) && obj._index == 2 && Program._isEditVisible)
                {
                    DeleteItem(_itemToEditIndex);
                }

                if ((x >= obj._frameObj._clientX1 && x <= obj._frameObj._clientX2) && (y >= obj._frameObj._clientY1 && y <= obj._frameObj._clientY2) && obj._index == 1 && Program._isEditVisible)
                {
                    Edit(_itemToEditIndex);
                }

            }

            foreach (var obj in editItems[0].subMenuItems)
            {

                if ((x >= obj._frameObj._clientX1 && x <= obj._frameObj._clientX2) && (y >= obj._frameObj._clientY1 && y <= obj._frameObj._clientY2) && obj._index == 0 && Program._isEditVisible && obj._isVisible)
                {
                    int k = 0;
                    foreach (var vari in _menuItems)
                    {
                        if (vari._isAbsolute)
                            k++;
                    }
                    AddItem("rectangle", 10 + 170*k, 20, 14, "text", 100, 100, 255);
                }

                if ((x >= obj._frameObj._clientX1 && x <= obj._frameObj._clientX2) && (y >= obj._frameObj._clientY1 && y <= obj._frameObj._clientY2) && obj._index == 1 && Program._isEditVisible && obj._isVisible)
                {
                    AddSubmenu(_itemToEditIndex);
                }

            }

        }

        private void Edit(int index)
        {
            
            for (int i = 0; i < _menuItems.Length; i++)
            {
                if (_menuItems[i]._index == index)
                {
                    int j = i - 1;
                    for (; j >= 0; j--)
                    {
                        if (_menuItems[j]._isAbsolute)
                        {
                            break;
                        }
                    }
                    EditForm edit = new EditForm(_menuItems[i], j >= 0 ? _menuItems[j]._frameObj._clientX2 :_menuItems[i]._frameObj._clientX1 );
                    edit.Show();
                    break;
                }
            }
        }

        public void AddItem(string objType, int x, int y, int fontSize, string text, int tR, int tG, int tB)
        {
                resizeArr(_menuItems);

                Rectangle obj = _gameField.generateRandomRectangle();
                changePos(obj,x , y);
                resize(obj, 100, 50);

                _menuItems[_curItemPos] = new MenuItem(x, y, fontSize, text, "Arial", tR, tG, tB, obj, _p, _gameField);

                _menuItems[_curItemPos]._curShiftX = _menuItems[_curItemPos]._frameObj._clientX2;
                _menuItems[_curItemPos]._curShiftY = _menuItems[_curItemPos]._frameObj._clientY2;

                _menuItems[_curItemPos]._isAbsolute = true;

                _p++;
                _curItemPos++;
            
        }

        private void resizeArr(MenuItem[] arr)
        {
            MenuItem[] newArray = new MenuItem[arr.Length + 1];

            Array.Copy(arr, newArray, arr.Length);

            _menuItems = newArray;
        }

        public void AddSubmenu(int index)
        {
            for (int i = 0; i < _menuItems.Length; i++)
            {
                if (_menuItems[i]._index == index)
                {
                    _menuItems[i]._isParent = true;
                    if (_menuItems[i]._submenuCount == 0 && _menuItems[i]._isAbsolute)
                    {
                        _menuItems[i]._curShiftX += 10;
                        _menuItems[i]._curShiftY += 10;
                    }
                        
                    _menuItems[i]._submenuCount++;
                    insertMenu(i + _menuItems[i]._submenuCount, 
                        AddRandomSubitem(_objTypes[0], _menuItems[i]._curShiftX , _menuItems[i]._curShiftY, 14, "Text", 100, 100, 255));
                    _curItemPos++;
            
                    _menuItems[i]._curShiftX = _menuItems[i + _menuItems[i]._submenuCount]._frameObj._clientX1;
                    _menuItems[i]._curShiftY = _menuItems[i + _menuItems[i]._submenuCount]._frameObj._clientY2 + 10;
                    _menuItems[i + _menuItems[i]._submenuCount]._isParent = false;
                    _menuItems[i + _menuItems[i]._submenuCount]._isVisible = true;
                    _menuItems[i + _menuItems[i]._submenuCount]._parentIndex = index;

                    _menuItems[i + _menuItems[i]._submenuCount]._curShiftX = _menuItems[i + _menuItems[i]._submenuCount]._frameObj._clientX2 + 10;
                    _menuItems[i + _menuItems[i]._submenuCount]._curShiftY = _menuItems[i + _menuItems[i]._submenuCount]._frameObj._clientY1;

                    _menuItems[i + _menuItems[i]._submenuCount]._index = _p;
                    _p++;

                    break;
                }
            }
        }

        private void insertMenu(int index, MenuItem obj)
        {
            MenuItem[] newArray = new MenuItem[_menuItems.Length + 1];

            Array.Copy(_menuItems, newArray, index);
            newArray[index] = obj;

            Array.Copy(_menuItems, index, newArray, index + 1, _menuItems.Length - index);

            _menuItems = newArray;
        }

        public void DeleteItem(int index)
        {
            for (int i = 0; i < _menuItems.Length; i++)
            {
                if (_menuItems[i]._index == index)
                {

                    if (_menuItems.Length == 1)
                    {
                        MenuItem[] newArray = new MenuItem[_menuItems.Length - 1];
                        _menuItems = newArray;
                        _curItemPos--;
                        break;
                    }

                    if (_menuItems[i]._isParent)
                    {
                        int len = 1 + _menuItems[i]._submenuCount;

                        for (int j = i + 1; j < len; j++)
                        {
                            if (_menuItems[j]._isParent)
                            {
                                len += _menuItems[j]._submenuCount;
                            }

                        }

                        _curItemPos -= len;

                        MenuItem[] newArray = new MenuItem[_menuItems.Length - len];

                        int pIndex = _menuItems[i]._parentIndex;

                        Array.Copy(_menuItems, newArray, i);
                        Array.Copy(_menuItems, i + 1 + _menuItems[i]._submenuCount, newArray, i, _menuItems.Length - i - len);

                        _menuItems = newArray;

                        for (int j = 0; j < _menuItems.Length; j++)
                        {
                            if (_menuItems[j]._index == pIndex)
                            {
                                _menuItems[j]._submenuCount -= 1;
                                break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        MenuItem[] newArray = new MenuItem[_menuItems.Length - 1];
                        int pIndex = _menuItems[i]._parentIndex;

                        Array.Copy(_menuItems, 0, newArray, 0, i);

                        Array.Copy(_menuItems, i + 1, newArray, i, _menuItems.Length - i - 1);

                        _menuItems = newArray;

                        _curItemPos--;

                        for (int j = 0; j < _menuItems.Length; j++)
                        {
                            if (_menuItems[j]._index == pIndex)
                            {
                                _menuItems[j]._submenuCount -= 1;
                                break;
                            }
                        }

                        break;
                    }
                }
            }
        }
    }
}